using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AverageGrades
{
    /*class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double Average => Grades.Average();
    }*/
    class Student1
    {
        public string Name { get; set; }
        public double[] Grades { get; set; }
        public double Average
        {
            get
            {
               return Grades.Average();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Student student = new Student();

                string[] inputArguments = Console.ReadLine().Split();
                student.Name = inputArguments[0];
                student.Grades = inputArguments.Skip(1).Select(double.Parse).ToList();
                students.Add(student);
            }
            students.Where(s => s.Average >= 5.00)
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.Average)
                .ToList().ForEach(s => Console.WriteLine($"{s.Name} -> {s.Average:F2}"));
                */

            int n = int.Parse(Console.ReadLine());

            List<Student1> students = new List<Student1>();

            while (n-- > 0)
            {
                var line = Console.ReadLine().Split(' ');
                string name = line[0];
                var grades = line.Skip(1).Select(double.Parse).ToArray();

                Student1 student = new Student1();
                student.Name = name;
                student.Grades = grades;

                students.Add(student);
            }
            students = students.Where(s => s.Average >= 5.00)
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.Average).ToList();

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name} -> {s.Average:F2}");
            }

        }
    }
}
