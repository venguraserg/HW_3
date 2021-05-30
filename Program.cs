using System;
using System.Runtime.InteropServices;


namespace HW_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Обьявление переменных
            bool correctParse = false;
            int menuMode, gameMode;
            char yn;

            // Бесконечный цикл, условие выхода gameMode = 3
            do
            {
                #region  Выбор режима игры
                /* Вывод меню
                * 1 - Игра
                * 2 - Правила
                * 3 - выход
                */
                
                
                // цикл меню, пока ввод не корректен крутимся в меню
                do
                {
                    Console.Clear();
                    Console.WriteLine("/*****************************************/");
                    Console.WriteLine("/                 Меню                    /");
                    Console.WriteLine("/*****************************************/");
                    Console.WriteLine("/              1. Игра                    /");
                    Console.WriteLine("/              2. Правила игры            /");
                    Console.WriteLine("/              3. Выйти                   /");
                    Console.WriteLine("/*****************************************/");
                    Console.WriteLine("Введите пункт меню. . .");
                    correctParse = int.TryParse(Console.ReadLine(), out menuMode);
                }
                while (!(correctParse && (menuMode > 0 && menuMode < 4))) ;
                #endregion
                
                // основное меню
                switch (menuMode)
                {
                    // Кейс алгоритма игры
                    case 1:
                        #region Надстройка вариантов игры
                        // цикл выбора типа игры, условие выхода - выбор из диапазона меню
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("/*****************************************/");
                            Console.WriteLine("/                 Меню игры               /");
                            Console.WriteLine("/*****************************************/");
                            Console.WriteLine("/              1. Игра 1х1                /");
                            Console.WriteLine("/              2. Игра 2-4 игрока         /");
                            Console.WriteLine("/              3. Игра против компьютера  /");
                            Console.WriteLine("/              4. Назад                   /");
                            Console.WriteLine("/*****************************************/");
                            Console.WriteLine("Введите пункт меню. . .");
                            correctParse = int.TryParse(Console.ReadLine(), out gameMode);
                        }
                        while (!(correctParse && (gameMode > 0 && gameMode < 5)));
                        
                        Random randomNumber = new Random();                                                 // Инициализация определения случайных чисел
                        int minRandomNumber=12, maxRandomNumber=121, maxPlayer=2;                           // Обьявление переменных
                        string[] users = new string[5] { "Computer", "user1", "user2", "user3", "user4" };  // Обьявление строкового массива игроков 
                        Console.Clear();
                        /*
                         * Собственно на оценку два варианта кода по надстройке для выбора режима игры
                         *
                         * Первый вариант на основе switch/case он более громоздкий и встречаются повторения кода,
                         * но по моему он проще читается, я его закоменил и решил оставить так цель ДЗ изучение switch/case в том числе
                         *
                         * Второй вариант немного короче, там в основном ветвления на if и циклы, но мне читать его сложнее, да и придумал его
                         * уже перед отправкой и написал за минут 5 (так сказать озорение)))))))))
                         *
                         * короче решил оставить два варианта на суд
                         */

                        #region Надстройка по вариантам игры Ver_1

                        //switch (gameMode)                                                                   // Выбор режима игры для преднастройки параметров игры
                        //{
                        //    case 1:                                                                         // Кейс 1х1
                        //        Console.WriteLine("Игра 1х1");                                              // Вывод сообщения на экран
                        //        minRandomNumber = 12;                                                       // Задаем мин диапазон генерации псевдослучайных чисел
                        //        maxRandomNumber = 121;                                                      // Задаем макс диапазон генерации псевдослучайных чисел
                        //        maxPlayer = 2;                                                              // задаем количество игроков - 2
                        //        Console.WriteLine("Пожалуйста представьтесь: ");
                        //        for (int i = 1; i < 3; i++)                                                 // Цикл ввода имени
                        //        {
                        //            Console.WriteLine($"Игрок №{i} введите свои имя");
                        //            users[i] = Console.ReadLine();
                        //        }
                        //        break;
                        //    case 2:                                                                         // Кейс 2-4 игрока       
                        //        Console.WriteLine("Игра 2-4 игрока");
                        //        Console.WriteLine("Выберите количество играков от 2х до 4х");
                        //        // цикл ввода количества игроков, пока ввод не корректен крутимся в нем
                        //        do
                        //        {
                        //            correctParse = int.TryParse(Console.ReadLine(), out maxPlayer);
                        //            if (maxPlayer <= 1 || maxPlayer >= 5) Console.WriteLine("Не верный ввод, повторите");
                        //        }
                        //        while (!(correctParse && (maxPlayer > 1 && maxPlayer < 5)));

                        //        Console.WriteLine("Введите дипазон чисел для случайного определения числа");
                        //        Console.WriteLine("Введите МИНимальный предел");
                        //        // цикл ввода мин диапазона генерации псевдослучайных чисел, пока ввод не корректен крутимся в нем
                        //        do
                        //        {
                        //            correctParse = int.TryParse(Console.ReadLine(), out minRandomNumber);
                        //            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        //        }
                        //        while (!(correctParse));

                        //        Console.WriteLine("Введите МАКСимальный предел");
                        //        // цикл ввода макс диапазона генерации псевдослучайных чисел, пока ввод не корректен крутимся в нем
                        //        do
                        //        {
                        //            correctParse = int.TryParse(Console.ReadLine(), out maxRandomNumber);
                        //            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        //        }
                        //        while (!(correctParse));
                        //        // Цикл ввода имени игроков
                        //        Console.WriteLine("Пожалуйста представьтесь: ");
                        //        for (int i = 1; i <= maxPlayer; i++)
                        //        {
                        //            Console.WriteLine($"Игрок №{i} введите свои имя");
                        //            users[i] = Console.ReadLine();
                        //        }
                        //        break;
                        //    case 3:                                                                                 // Кейс надстройка для игры с компом
                        //        Console.WriteLine("Игра против компьютера");
                        //        Console.WriteLine("Пожалуйста представьтесь: ");
                        //        users[1] = Console.ReadLine();
                        //        Console.WriteLine("Введите дипазон чисел для случайного определения числа");
                        //        Console.WriteLine("Введите МИНимальный предел");
                        //        do
                        //        {
                        //            correctParse = int.TryParse(Console.ReadLine(), out minRandomNumber);
                        //            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        //        }
                        //        while (!(correctParse));

                        //        Console.WriteLine("Введите МАКСимальный предел");
                        //        do
                        //        {
                        //            correctParse = int.TryParse(Console.ReadLine(), out maxRandomNumber);
                        //            if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                        //        }
                        //        while (!(correctParse));

                        //        maxPlayer = 1;

                        //        break;
                        //    case 4:
                        //        break;

                        //}
                        #endregion

                        #region Надстройка по вариантам игры Ver_2
                        Console.WriteLine(gameMode==1 ? "Игра 1х1": (gameMode==2 ? "Игра 2-4 игрока" : "Игра против компьютера"));
                        if (gameMode == 1)
                        {
                            minRandomNumber = 12;                                                       // Задаем мин/макс диапазон генерации псевдослучайных чисел
                            maxRandomNumber = 121;
                            maxPlayer = 2;
                        }
                        else 
                        {
                            Console.WriteLine("Введите дипазон чисел для случайного определения числа");
                            Console.WriteLine("Введите МИНимальный предел");
                            do
                            {
                                correctParse = int.TryParse(Console.ReadLine(), out minRandomNumber);
                                if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                            }
                            while (!(correctParse));

                            Console.WriteLine("Введите МАКСимальный предел");
                            do
                            {
                                correctParse = int.TryParse(Console.ReadLine(), out maxRandomNumber);
                                if (!correctParse) Console.WriteLine("Не верный ввод, повторите");
                            }
                            while (!(correctParse));

                            if (gameMode == 2)
                            {
                                Console.WriteLine("Выберите количество играков от 2х до 4х");
                                // цикл ввода количества игроков, пока ввод не корректен крутимся в нем
                                do
                                {
                                    correctParse = int.TryParse(Console.ReadLine(), out maxPlayer);
                                    if (maxPlayer <= 1 || maxPlayer >= 5) Console.WriteLine("Не верный ввод, повторите");
                                }
                                while (!(correctParse && (maxPlayer > 1 && maxPlayer < 5)));
                            }
                            else
                            {
                                maxPlayer = 1;
                            }
                        }
                        // Цикл ввода имени игроков
                        Console.WriteLine("Пожалуйста представьтесь: ");
                        for (int i = 1; i <= maxPlayer; i++)
                        {
                            Console.WriteLine($"Игрок №{i} введите свои имя");
                            users[i] = Console.ReadLine();
                        }
                        #endregion

                        #endregion
                        #region Собственно сам универсальный алгоритм игры


                        bool revenge = false;
                        do
                        {
                            var gameNumber = randomNumber.Next(minRandomNumber, maxRandomNumber);
                            var player = randomNumber.Next(gameMode == 3 ? 0 : 1,
                                gameMode == 1 ? 3 : (gameMode == 2 ? maxPlayer + 1 : 2));
                            bool standoff = false;
                            int userTry;


                            while (gameNumber != 0)
                            {
                                if (player > maxPlayer) player = gameMode == 3 ? 0 : 1;
                                Console.Clear();
                                Console.WriteLine($"gameNumber= {gameNumber}");

                                Console.WriteLine($"Ход игрока {users[player]}");

                                if (player == 0)
                                {
                                    userTry = randomNumber.Next(1, 5);
                                    Console.WriteLine($"Компьютер выбрал число - '{userTry}'\nДля продолжения нажмите любую кнопку...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    int.TryParse(Console.ReadLine(),out userTry);
                                }

                                if (userTry < 1 || userTry > 4)
                                {
                                    userTry = 0;
                                    Console.WriteLine("Вы ввели не верное число, вы пропускаете это ход");
                                    Console.ReadKey();
                                }

                                gameNumber -= userTry;

                                if (gameNumber < 0)
                                {
                                    standoff = true;
                                    break;
                                }
                                if (gameNumber != 0) player++;
                            }

                            #region Определение победителя

                            Console.Clear();
                            Console.WriteLine(standoff
                                ? " НИКТО, УРА, ДРУЖЕСКАЯ НИЧЬЯ"
                                : $"Победитель: {users[player]} ");

                            Console.WriteLine("Может быть реванш?? (y/n)");

                            do
                            {
                                correctParse = char.TryParse(Console.ReadLine(), out yn);
                                if (!(yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y'))
                                {
                                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                                }
                            } while (!(correctParse && (yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y')));

                            if (yn == 'y' || yn == 'Y')
                            {
                                revenge = true;
                            }
                            else if (yn == 'n' || yn == 'N')
                            {
                                revenge = false;
                            }

                            Console.WriteLine(revenge
                                ? "Отлично, давай повторим\nДля продолжения нажмите любую кнопку..."
                                : "Хорошо, возвращаемся в главное меню\nДля продолжения нажмите любую кнопку...");
                            Console.ReadKey();

                            #endregion


                        } while (revenge);
                        
                        break;
                    #endregion
                    case 2:
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
                    case 3:
                        #region Кейс выхода из приложения
                        Console.Clear();
                        Console.WriteLine("ВЫЙТИ ИЗ ПРИЛОЖЕНИЯ  (y/n)?:");
                        //char yn;
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
