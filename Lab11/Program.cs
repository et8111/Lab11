using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static List<Movie> loader(List<Movie> movies)
        {
            movies.Add(new Movie("Predator", "Scifi"));
            movies.Add(new Movie("Bad Times at the El Royal", "Drama"));
            movies.Add(new Movie("Good Fellas", "Drama"));
            movies.Add(new Movie("Dogma", "Scifi"));
            movies.Add(new Movie("Rugrats Movie", "Animation"));
            movies.Add(new Movie("How to train you dragon", "Animation"));
            movies.Add(new Movie("Maximum Overdrive", "Horror"));
            movies.Add(new Movie("The Conjuring", "Horror"));
            movies.Add(new Movie("Halloween", "Horror"));
            movies.Add(new Movie("IT", "Horror"));
            return movies.OrderBy(a => a.Title).ToList();
        }
        static void print(List<Movie> movies, string shower)
        {
            Console.WriteLine($"~DISPLAYING {shower.ToUpper()}~");
            Console.WriteLine("=".PadLeft(shower.Length+13,'='));
            foreach (var v in movies)
                Console.WriteLine($"{v.Title,-25}");//|{v.getCata(),-9}|");
            Console.WriteLine();
        }

        static void printHelper(List<Movie> movies, List<string> show)
        {
            List<Movie> tempMovie = new List<Movie>();
            Console.WriteLine("Chooose your weapon: ");
            for(int i = 0; i < show.Count; i++)
                Console.WriteLine($"{i+1}) {show[i]}");
            Console.WriteLine("6) Exit");
            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice > 6 || choice < 1))
            {
                Console.WriteLine("BAD");
                printHelper(movies, show);
            }
            if (choice >= 6 || choice < 1)
                return;
            else if (choice == 5)
            {
                print(movies, show[4]);
            }
            else if (choice <= 6 && choice >= 1)
            {
                tempMovie = movies.Where(a => a.Category == show[choice - 1]).ToList();
                print(tempMovie, show[choice - 1]);
            }
            printHelper(movies, show);
        }

        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            List<string> show = new List<string>() { "Animation", "Drama", "Horror", "Scifi", "All" };
            movies = loader(movies);
            printHelper(movies, show);
        }
    }
}
