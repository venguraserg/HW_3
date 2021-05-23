using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HW_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string rulesOfGame = "ПРАВИЛА ИГРЫ\n" +
                                 "Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.\n"+
                                 "Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.\n" +
                                 "UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.\n"+
                                 "Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.\n";

            
            Random randomNumber = new Random();
            int gameNumber = randomNumber.Next(12, 121);
            Console.WriteLine(rulesOfGame);
            Console.WriteLine("Для начала игры нужно представится, чтобы продолжить - нажмите любую клавишу. . .");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Игрок №1 введите свое имя: ");
            var userName_1 = Console.ReadLine();
            Console.Clear();
            Console.Write("Игрок №2 введите свое имя: ");
            var userName_2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Итак, приветствую {userName_1} и {userName_2}");
            int firstPlayer = randomNumber.Next(1, 3);
            string firstPlayerName, secondPlayerName;
            if (firstPlayer == 1)
            {
                firstPlayerName = userName_1;
                secondPlayerName = userName_2;
            }
            else
            {
                firstPlayerName = userName_2;
                secondPlayerName = userName_1;
            }

            

            Console.WriteLine("Первым начинает {0}", firstPlayerName);

            



            Console.ReadKey();

        }
    }
}
