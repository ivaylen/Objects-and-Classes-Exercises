using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TeamworkProjects
{
    class Team{
        public string TeamName { set; get; }
        public List<string> MembersList { set; get; }
        public string CreatorName { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            createTeams(n, teams);
            getUsersToMembersList(teams);
            printResult(teams);
        }

        private static void printResult(List<Team> teams)
        {
            foreach (var item in teams.Where(t => t.MembersList.Count > 0)
                .OrderByDescending(t => t.MembersList.Count).ThenBy(t => t.TeamName))
            {
                Console.WriteLine(item.TeamName);
                Console.WriteLine($"- {item.CreatorName}");

                foreach (var member in item.MembersList.OrderBy(a => a))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");

            foreach (var item in teams.Where(t => t.MembersList.Count < 1).OrderBy(t => t.TeamName))
            {
                Console.WriteLine(item.TeamName);
            }
        }

        private static void getUsersToMembersList(List<Team> teams)
        {
            string command = Console.ReadLine();

            while(command != "end of assignment")
            {
                var commandArgs = command.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                var userName = commandArgs[0];
                var teamName = commandArgs[1];

                bool teamExists = false;
                bool userAlreadyInTeam = false;
                bool userCreatorOfTeam = false;

                foreach (var t in teams)
                {
                    if(t.TeamName == teamName)
                    {
                        teamExists = true;
                    }
                    if (t.MembersList.Contains(userName))
                    {
                        userAlreadyInTeam = true;
                    }
                    if(t.CreatorName == userName)
                    {
                        userCreatorOfTeam = true;
                    }
                }
                if (!teamExists)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }else if(userAlreadyInTeam || userCreatorOfTeam)
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                }
                else
                {
                    foreach (var t in teams)
                    {
                        if(t.TeamName == teamName)
                        {
                            t.MembersList.Add(userName);
                        }
                    }
                }
                command = Console.ReadLine();
            }
        }

        private static void createTeams(int n, List<Team> teams)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('-');
                var creator = input[0];
                var nameOfTeam = input[1];

                Team team = new Team();
                team.TeamName = nameOfTeam;
                team.CreatorName = creator;
                team.MembersList = new List<string>();

                bool teamAlreadyCreated = false;
                bool userAlreadyHasAteam = false;

                foreach (var t in teams)
                {
                    if(t.TeamName == team.TeamName)
                    {
                        teamAlreadyCreated = true;
                    }
                    if(t.CreatorName == team.CreatorName)
                    {
                        userAlreadyHasAteam = true;
                    }
                }
                if (teamAlreadyCreated)
                {
                    Console.WriteLine($"Team {team.TeamName} was already created!");
                    continue;
                } else if (userAlreadyHasAteam)
                {
                    Console.WriteLine($"{team.CreatorName} cannot create another team!");
                    continue;
                }
                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {team.TeamName} has been created by {team.CreatorName}!");
                }
            }
        }
    }
}
