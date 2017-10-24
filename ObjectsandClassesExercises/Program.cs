using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsandClassesExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var dateAsString = Console.ReadLine();
            var date = DateTime.ParseExact(
                dateAsString, "d-M-yyyy",
                CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
            */

            /*
            var words = Console.ReadLine()
                .Split(' ');
            var randon = new Random();            

            for (int i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                var randomIndex = randon.Next(0, words.Length);

                var tempWord = words[randomIndex];
                words[i] = tempWord;
                words[randomIndex] = currentWord;
            }
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
            */

            int n = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);

            /*
            var firstPointParts = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var firstPoint = new Point
            {
                X = (firstPointParts[0]),
                Y = (firstPointParts[1])
            };
            var secondPointParts = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var secondPoint = new Point
            {
                X = (secondPointParts[0]),
                Y = (secondPointParts[1])
            };
            var result = CalculateDistance(firstPoint, secondPoint);
            Console.WriteLine($"{result:F3}");
        }
        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            var diffX = firstPoint.X - secondPoint.X;
            var diffY = firstPoint.Y - secondPoint.Y;

            var powX = Math.Pow(diffX, 2);
            var powY = Math.Pow(diffY, 2);

            return Math.Sqrt(powX + powY);
        }*/
        }
    }
}
