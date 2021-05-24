using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_3
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                /* режим игры
             * 0 - 1х1
             * 1 - от 2х до 4х игроков
             * 2 - против компьютера
             * 3 - выход
             */
                int gameMode; // объявление переменной для хранения режима игры
                bool correctParse;
                Random randomNumber = new Random();
                do
                {
                    Console.Clear();
                    Console.WriteLine("/*****************************************/");
                    Console.WriteLine("/                 Меню игры               /");
                    Console.WriteLine("/*****************************************/");
                    Console.WriteLine("/              1. Два игрока              /");
                    Console.WriteLine("/              2. Больше двух игроков     /");
                    Console.WriteLine("/              3. Игра против ИИ:)        /");
                    Console.WriteLine("/              4. Правила игры            /");
                    Console.WriteLine("/              5. Выйти                   /");
                    Console.WriteLine("/*****************************************/");
                    Console.WriteLine("Введите пункт меню. . .");
                    correctParse = int.TryParse(Console.ReadLine(), out gameMode);
                }
                while (!(correctParse && (gameMode > 0 && gameMode < 6))) ;

                switch (gameMode)
                {
                    case 1:
                        int gameNumber = randomNumber.Next(12, 121);
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
                        break;
                    case 2:
                        Console.WriteLine("2");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("3");
                        Console.ReadKey();
                        break;
                    case 4:
                        int ruleNumber;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("/*****************************************/");
                            Console.WriteLine("/            Выберите тип игры            /");
                            Console.WriteLine("/*****************************************/");
                            Console.WriteLine("/              1. Два игрока              /");
                            Console.WriteLine("/              2. Больше двух игроков     /");
                            Console.WriteLine("/              3. Игра против ИИ:)        /");
                            Console.WriteLine("/              4. Выйти                   /"); 
                            Console.WriteLine("/*****************************************/");
                            Console.WriteLine("Введите пункт меню. . .");
                            correctParse = int.TryParse(Console.ReadLine(), out ruleNumber);
                            if (!(ruleNumber > 0 && ruleNumber < 5))
                            {
                                Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                                Console.ReadKey();
                            }
                        }
                        while (!(correctParse && (ruleNumber > 0 && ruleNumber < 5)));

                        switch (ruleNumber)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Когда играют два игрока:");
                                Console.WriteLine("Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.\n" +
                                                  "Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.\n" +
                                                  "UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.\n" +
                                                  "Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.\n");
                                Console.WriteLine("Чтобы вернутся в меню, нажмите любую клавишу...");
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Когда играют больше двух игроков:");
                                Console.WriteLine("Загадывается число , причём случайным образом, диапазон указывают пользователи. Назовём его gameNumber.\n" +
                                                  "Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.\n" +
                                                  "UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.\n" +
                                                  "Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.\n");
                                Console.WriteLine("Чтобы вернутся в меню, нажмите любую клавишу...");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Когда играушь против компьютера:");
                                Console.WriteLine("Загадывается число , причём случайным образом, диапазон указывают пользователь. Назовём его gameNumber.\n" +
                                                  "Игрок и компьютер по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.\n" +
                                                  "UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.\n" +
                                                  "Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.\n");
                                Console.WriteLine("Чтобы вернутся в меню, нажмите любую клавишу...");
                                Console.ReadKey();
                                break;
                            case 4:
                                break;
                        }
                        
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("ВЫЙТИ ИЗ ПРИЛОЖЕНИЯ  (y/n)?:");
                        char yn;
                        do
                        {
                            correctParse = char.TryParse(Console.ReadLine(), out yn);
                            if(!(yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y'))
                            {
                                Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                            }
                        } while (!(correctParse && (yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y')));

                        if (yn == 'y' || yn == 'Y')
                        {
                            Environment.Exit(0);
                        }
                        else if (yn == 'n' || yn == 'N')
                        {
                            Console.WriteLine("Продолжим, нажми любую клавишу...");
                            Console.ReadKey();
                        }
                        break;
                }
            } while (true);
            

        }
    }
}
