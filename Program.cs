using System;
using System.Runtime.InteropServices;


namespace HW_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName_1, userName_2;
            // Бесконечный цикл, условие выхода gameMode = 5
            do
            {
                #region  Выбор режима игры
                /* режим игры
                * 0 - 1х1
                * 1 - от 2х до 4х игроков
                * 2 - против компьютера
                * 3 - выход
                */
                int gameMode;                       // объявление переменной для хранения режима игры
                bool correctParse;                  // объявление переменной корректности парсинга
                Random randomNumber = new Random(); //Инициализация определения случайных чисел
                
                // цикл меню, пока ввод не корректен крутимся в меню
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
                #endregion
                
                switch (gameMode)
                {
                    case 1:

                        #region Первый вариант игры

                        var gameNumber = randomNumber.Next(12, 121);            //определение случайной переменной randomNumber
                        // ввод данных пользователей 
                        Console.Clear();
                        Console.WriteLine("Для начала игры нужно представится, чтобы продолжить - нажмите любую клавишу. . .");
                        Console.ReadKey();
                        Console.Clear();
                        Console.Write("Игрок №1 введите свое имя: ");
                        // цикл обеспечивающий ввод имени пользователя
                        do
                        { 
                            userName_1 = Console.ReadLine();
                            if (userName_1 == "")
                            {
                                Console.WriteLine("Повторите ввод");
                            }
                        } while (userName_1=="");

                        // цикл обеспечивающий ввод имени пользователя 2
                        Console.Clear();
                        Console.Write("Игрок №2 введите свое имя: ");
                        do
                        {
                            userName_2 = Console.ReadLine();
                            if (userName_2 == "")
                            {
                                Console.WriteLine("Повторите ввод");
                            }
                        } while (userName_2 == "");

                        // Случайное определение, кто первый ходит, (в задании не указано, так сказать бонус)
                        Console.Clear();
                        Console.WriteLine($"Итак, приветствую {userName_1} и {userName_2}");
                        var firstPlayer = randomNumber.Next(1, 3);
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
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();

                        // цикл игры
                        var player = 0;
                        while (gameNumber!=0)
                        {
                            player++;
                            if (player > 2) player = 1;
                            Console.Clear();
                            Console.WriteLine($"gameNumber= {gameNumber}");
                            if (player == 1)
                            {
                                Console.WriteLine($"{firstPlayerName} выберите число от 1 до 4");
                            }
                            else
                            {
                                Console.WriteLine($"{secondPlayerName} выберите число от 1 до 4");
                            }
                            //можно применить тернарное выражение строчек меньше, но хуже читается код
                            //Console.WriteLine(player == 1
                            //    ? $"{firstPlayerName} выберите число от 1 до 4"
                            //    : $"{secondPlayerName} выберите число от 1 до 4");

                            var userTry = int.Parse(Console.ReadLine());
                            if (userTry < 1 || userTry > 4)
                            {
                                userTry = 0;
                                Console.WriteLine("Вы ввели не верное число, вы пропускаете это ход");
                                Console.ReadKey();
                            }

                            gameNumber -= userTry;
                            if (gameNumber < 0)
                            {
                                player = 0;
                                break;
                                
                            }
                            
                        }
                        
                        //определение победителя
                        Console.Clear();
                        Console.Write("Победитель: ");
                        switch (player)
                        {
                            case 1:
                                Console.WriteLine(firstPlayerName);
                                break;
                            case 2:
                                Console.WriteLine(secondPlayerName);
                                break;
                            default:
                                Console.WriteLine(" НИКТО, УРА, ДРУЖЕСКАЯ НИЧЬЯ");
                                break;

                        }

                        Console.WriteLine("Для выхода в меню нажмите любую кнопку...");
                        Console.ReadKey();
                        break;

                    #endregion
                    
                    case 2:

                        #region Второй вариант игры

                        int numberPlayer, minNumber, maxNumber; // обявление переменных
                        Console.Clear();
                        Console.WriteLine("Выберите количество играков от 2х до 4х");
                        // цикл меню, пока ввод не корректен крутимся в меню
                        do
                        {
                            correctParse = int.TryParse(Console.ReadLine(), out numberPlayer);
                            if (numberPlayer <= 1 || numberPlayer >= 5) Console.WriteLine("Не верный ввод, повторите");
                        }
                        while (!(correctParse && (numberPlayer > 1 && numberPlayer < 5)));
                        
                        Console.Clear();
                        Console.WriteLine("Введите дипазон чисел для случайного определения числа");
                        Console.WriteLine("Введите МИНимальный предел");
                        do
                        {
                            correctParse = int.TryParse(Console.ReadLine(), out minNumber);
                            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        }
                        while (!(correctParse));

                        Console.WriteLine("Введите МАКСимальный предел");
                        do
                        {
                            correctParse = int.TryParse(Console.ReadLine(), out maxNumber);
                            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        }
                        while (!(correctParse));

                        gameNumber = randomNumber.Next(minNumber, maxNumber+1);

                        Console.Clear();
                        Console.WriteLine("Для начала игры нужно представится, чтобы продолжить - нажмите любую клавишу. . .");
                        Console.ReadKey();
                        Console.Clear();
                        /*
                         * для разнообразности решил попробовать массив для хранения имен пользователей
                         * применение массива значительно сократило листинг
                         */
                        var userName = new string[numberPlayer]; // объявление массива

                        for (var i = 0; i < numberPlayer; i++)
                        {
                            Console.Clear();
                            Console.Write($"Игрок №{i + 1} введите свое имя: ");
                            do
                            {
                                userName[i] = Console.ReadLine();
                                if (userName[i] == "")
                                {
                                    Console.WriteLine("Повторите ввод");
                                }
                            } while (userName[i] == "");

                        }

                        // определение кто ходит первый
                        player = randomNumber.Next(0,4);
                        while (gameNumber != 0)
                        {
                            player++;
                            if (player > numberPlayer) player = 1;
                            Console.Clear();
                            Console.WriteLine($"gameNumber= {gameNumber}");

                            Console.WriteLine($"Ход игрока {userName[player-1]}");
                            
                            var userTry = int.Parse(Console.ReadLine());
                            if (userTry < 1 || userTry > 4)
                            {
                                userTry = 0;
                                Console.WriteLine("Вы ввели не верное число, вы пропускаете это ход");
                                Console.ReadKey();
                            }

                            gameNumber -= userTry;
                            if (gameNumber < 0)
                            {
                                player = 0;
                                break;
                            }

                        }

                        Console.Clear();
                        Console.WriteLine(player == 0
                            ? " НИКТО, УРА, ДРУЖЕСКАЯ НИЧЬЯ"
                            : $"Победитель: {userName[player - 1]} ");

                        Console.WriteLine("Для выхода в меню нажмите любую кнопку...");
                        Console.ReadKey();
                        break;
                        #endregion
                    
                    case 3:

                        #region Третий вариант игры
                        // ввод данных пользователей 
                        Console.Clear();
                        Console.WriteLine("Для начала игры нужно представится, чтобы продолжить - нажмите любую клавишу. . .");
                        Console.ReadKey();
                        Console.Clear();
                        Console.Write("Игрок №1 введите свое имя: ");
                        // цикл обеспечивающий ввод имени пользователя
                        do
                        {
                            userName_1 = Console.ReadLine();
                            if (userName_1 == "")
                            {
                                Console.WriteLine("Повторите ввод");
                            }
                        } while (userName_1 == "");

                        Console.Clear();
                        Console.WriteLine("Введите дипазон чисел для случайного определения числа");
                        Console.WriteLine("Введите МИНимальный предел");
                        do
                        {
                            correctParse = int.TryParse(Console.ReadLine(), out minNumber);
                            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        }
                        while (!(correctParse));

                        Console.WriteLine("Введите МАКСимальный предел");
                        do
                        {
                            correctParse = int.TryParse(Console.ReadLine(), out maxNumber);
                            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        }
                        while (!(correctParse));

                        gameNumber = randomNumber.Next(minNumber, maxNumber + 1);

                        // Случайное определение, кто первый ходит, (в задании не указано, так сказать бонус)
                        Console.Clear();
                        Console.WriteLine($"Итак, приветствую {userName_1}");
                        firstPlayer = randomNumber.Next(1, 3);
                        
                        if (firstPlayer == 1)
                        {
                            firstPlayerName = userName_1;
                            secondPlayerName = "Компьютер";
                        }
                        else
                        {
                            firstPlayerName = "Компьютер";
                            secondPlayerName = userName_1;
                        }

                        Console.WriteLine("Первым начинает {0}", firstPlayerName);
                        Console.WriteLine("Для продолжения нажмите любую клавишу...");
                        Console.ReadKey();

                        // цикл игры
                        player = 0;
                        while (gameNumber != 0)
                        {
                            player++;
                            var userTry = 0;
                            if (player > 2) player = 1;
                            Console.Clear();
                            Console.WriteLine($"gameNumber= {gameNumber}");


                            if (player == 1)
                            {
                                if (firstPlayer == 1)
                                {
                                    Console.WriteLine($"{firstPlayerName} выберите число от 1 до 4");
                                    userTry = int.Parse(Console.ReadLine());
                                    if (userTry < 1 || userTry > 4)
                                    {
                                        userTry = 0;
                                        Console.WriteLine("Вы ввели не верное число, вы пропускаете это ход");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    userTry = randomNumber.Next(1, 5);
                                    Console.WriteLine("Ход компьютера - {0}\n Нажмите любую кнопку...",userTry);
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                if (firstPlayer != 1)
                                {
                                    Console.WriteLine($"{secondPlayerName} выберите число от 1 до 4");
                                    userTry = int.Parse(Console.ReadLine());
                                    if (userTry < 1 || userTry > 4)
                                    {
                                        userTry = 0;
                                        Console.WriteLine("Вы ввели не верное число, вы пропускаете это ход");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    userTry = randomNumber.Next(1, 5);
                                    Console.WriteLine("Ход компьютера - {0}\n Нажмите любую кнопку...", userTry);
                                    Console.ReadKey();
                                }
                            }

                            

                            gameNumber -= userTry;
                            if (gameNumber < 0)
                            {
                                player = 0;
                                break;

                            }

                        }

                        //определение победителя
                        Console.Clear();
                        Console.Write("Победитель: ");
                        switch (player)
                        {
                            case 1:
                                Console.WriteLine(firstPlayerName);
                                break;
                            case 2:
                                Console.WriteLine(secondPlayerName);
                                break;
                            default:
                                Console.WriteLine(" НИКТО, УРА, ДРУЖЕСКАЯ НИЧЬЯ");
                                break;

                        }

                        Console.WriteLine("Для выхода в меню нажмите любую кнопку...");
                        Console.ReadKey();

                        break;
                        #endregion
                    
                    case 4:

                        #region Вывод правил игры
                        int ruleNumber;                         // объявление переменной для типа игры
                        do                                      // цикл для выбоа пункта меню
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
                            correctParse = int.TryParse(Console.ReadLine(), out ruleNumber); // ввод и проверка значения с клавиатуры
                            if (ruleNumber > 0 && ruleNumber < 5) continue;
                            Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                            Console.ReadKey();
                        }
                        while (!(correctParse && (ruleNumber > 0 && ruleNumber < 5)));

                        // Вывод пункта правил
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
                    #endregion
                   
                    case 5:

                        #region Кейс выхода из приложения
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
                        #endregion
                
                }
            } while (true);
            

        }
    }
}
