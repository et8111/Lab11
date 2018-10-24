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
            Console.WriteLine($"~DISPLAYING {shower.ToUpper()}~");          //Display sorter
            Console.WriteLine("=".PadLeft(shower.Length+13,'='));           //print all movies that apply to sorter
            foreach (var v in movies)                                       //
                Console.WriteLine($"{v.Title,-25}");                        //
            Console.WriteLine();                                            //
        }

        static void printHelper(List<Movie> movies, List<string> show)
        {
            Console.WriteLine("Chooose your weapon: ");       //Display possible categories      
            for (int i = 0; i < show.Count; i++)              //
                Console.WriteLine($"{i+1}) {show[i]}");       //
            Console.WriteLine("6) Exit");                     //
            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice > 6 || choice < 1))//user validation
            {                                                                                   //
                Console.WriteLine("BAD");                                                       //
                printHelper(movies, show);                                                      //
            }
            if (choice >= 6 || choice < 1)                   //Exit (not 'else if' on purpose, has condition as
                return;                                      //well in order to catch bad inputs and not crash)
            else if (choice == 5)             //Display all                                                                                                                         
                print(movies, show[4]);       //categories 
            else if (choice <= 6 && choice >= 1)                                                     //***display special category by lambda filtering***
                print(movies.Where(a => a.Category == show[choice - 1]).ToList(), show[choice - 1]); //***into 'movies' based on'choice', then send through 'print()'***
            printHelper(movies, show);          //recursion
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