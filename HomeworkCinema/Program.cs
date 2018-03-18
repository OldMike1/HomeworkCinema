using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkCinema
{
    public struct Human
    {
        public int Age;
        public char Sex;
    }

    public struct Cinema
    {
        public Human[,] human;
        public Random rnd;
        public int CountOfPeople;
        public char[] Sex;
        List<Human> listOfHuman; 

        public Cinema(int x, int y, int countOfPeople)
        {
            human = new Human[x, y];
            rnd = new Random();
            this.CountOfPeople = countOfPeople;
            Sex = new char[2] { 'M', 'F' };
            listOfHuman = new List<Human>();
        }

        public void SetPeople()
        {
            int x, y;

            for (int i = 0; i < CountOfPeople; i++)
            {
                while (true)
                {
                    x = rnd.Next(0, human.GetLength(0));
                    y = rnd.Next(0, human.GetLength(1));
                    if (human[x, y].Age == 0)
                    {
                        human[x, y] = new Human { Age = rnd.Next(16, 60), Sex = Sex[rnd.Next(0, 2)] };
                        listOfHuman.Add(human[x, y]);
                        break;
                    }
                }
            }
        }

        public void GetAll()
        {
            int allM = 0;
            int ageM = 0;
            int ageF = 0;
            foreach (var item in listOfHuman)
            {
                if (item.Sex != 'F')
                    allM++;
                if (item.Age != 0 && item.Sex != 'F')
                    ageM += item.Age;
                if (item.Age != 0 && item.Sex != 'M')
                    ageF += item.Age;
            }
            Console.WriteLine("All people - "+CountOfPeople);
            int allF = CountOfPeople - allM;
            Console.WriteLine("M - "+allM);
            Console.WriteLine("F - "+allF);
            int middleAgeM = ageM / allM;
            Console.WriteLine("Middle age M - "+middleAgeM);
            int middleAgeF = ageF / allF;
            Console.WriteLine("Middle age F - "+middleAgeF);
            int middleAgeAll = (ageM + ageF) / CountOfPeople;
            Console.WriteLine("Middle age all - "+middleAgeAll);
        }
    }

    class Program
    {
        static void PrintCinema(Cinema cinema)
        {
            for (int i = 0; i < cinema.human.GetLength(0); i++)
            {
                for (int j = 0; j < cinema.human.GetLength(1); j++)
                {
                    if (cinema.human[i, j].Age != 0)
                        Console.Write(" " + cinema.human[i, j].Sex + " ");
                    else
                        Console.Write(" - ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Cinema cinema = new Cinema(8, 8, 25);
            cinema.SetPeople();
            PrintCinema(cinema);
            cinema.GetAll();
            Console.WriteLine();

            Cinema cinema2 = new Cinema(18, 18, 25);
            cinema2.SetPeople();
            PrintCinema(cinema2);
            cinema2.GetAll();

        }
    }
}
