using System;
using System.IO;
using System.Text;

namespace JuniorTest
{
    public class LoadFile
    {
        // Слишком много хлама :(
        private StreamReader fileQuestions;
        private string[] answers;
        private string[] variants;
        private const int index = 10;
        private readonly string[] CorrectAnswersJuniorTest = { "3) b.", "2) 2.", "3) 9254.", "4) private.", "1) В виде структур.", "4) Из конструктора, либо в месте объявления поля, приравнивая ему какое-то значение.", "4) lock.", "4) System.Object", "1) true, false, true, true.", "2) Напечатает слово \"test\".", "1) ABC.", "5) IEnumerable.", "2) Catch Exception, Catch MyCustomException.", "2) 10, 10, 10, 10, 10, 10, 10, 10, 10, 10.", "1) Чтение - О(1), запись - О(1).", "2) Параметр с ключевым словом out может быть не инициализирован, а параметр с ключевым словом ref обязательно должен быть инииализирован до вызова метода, который использует эти параметры.", "4) false, false.", "2) Не является ни в каком случае.", "3) В случае ошибки cast выбрасывает исключение InvalidCastException, а оператор as возвращает null.", "4) Всегда будет напечатано слово \"test\".", "1) Один раз при первом создании экземпляра класса или при первом обращении к статическим членам класса.", "5) readonly можно только в конструкторе.", "5) Distinct()", "Вопрос №24", "Вопрос №25", "Вопрос №26", "Вопрос №27", "Вопрос №28", "Вопрос №29", "Вопрос №30", "Вопрос №31", "Вопрос №32", "Вопрос №33", "Вопрос №34", "Вопрос №35", "Вопрос №36", "Вопрос №37", "Вопрос №38", "Вопрос №39" };
        private readonly string[] CorrectAnswersCodeBlog = { "1) Вадим.", "2) бла бла бла.", "3) бла бла бла."};
        private readonly string[] CorrectAnswersQuestions = { "Вопрос №1", " Вопрос №2", "Вопрос №3 ", " Вопрос №4", "Вопрос №5 ", "Вопрос №6", "Вопрос №7", "Вопрос №8", "Вопрос №9", "Вопрос №10", "Вопрос №11", "Вопрос №12", "Вопрос №13", "Вопрос №14", "Вопрос №15", "Вопрос №16", "Вопрос №17", "Вопрос №18", "Вопрос №19", "Вопрос №20", "Вопрос №21", "Вопрос №22", "Вопрос №23", "Вопрос №24", "Вопрос №25", "Вопрос №26", "Вопрос №27", "Вопрос №28", "Вопрос №29", "Вопрос №30", "Вопрос №31", "Вопрос №32", "Вопрос №33", "Вопрос №34", "Вопрос №35", "Вопрос №36", "Вопрос №37", "Вопрос №38"};
        private int numberQuestions = 0;
        private int count = 0; // Переменная для массива ответов пользователя
        private string line;
        private int variantsCount = 0;

        public LoadFile(string pathQuestions, int numbers)
        {
            numberQuestions = numbers;
            answers = new string[numbers];
            variants = new string[index];
            fileQuestions = new StreamReader(pathQuestions, Encoding.Default);
        }

        // Функция поочередно считывает вопросы из файла и ответы пользователя
        // количество итераций равно количеству вопросов
        public void Start()
        {
            Console.Clear();

            for (int i = 0; i < numberQuestions; i++)
            {
                Questions();
                Answer();
                Console.Clear();
            }

            fileQuestions.Close();
        }

        public void StartQuestions()
        {
            Console.Clear();

            for (int i = 0; i < numberQuestions; i++)
            {
                QuestionsFromQuestions();
                AnswerQuestions();
                Console.Clear();
            }

            fileQuestions.Close();
        }

        private void QuestionsFromQuestions()
        {
            while (true)
            {
                line = fileQuestions.ReadLine();

                if (line.EndsWith("~endque"))
                {
                    Console.WriteLine(line.Substring(0, line.Length - 7) + "\n"); // удаление метки конца вопроса
                    break;
                }

                else
                    Console.WriteLine(line);
            }
        }

        // Функция построчного считывания вопросов и вариантов ответа
        // Вопрос может состоять из нескольких строк, поэтому нужно знать когда остановить считывание для этого в коце строки добавляется
        // строка ~endque (End question), тоже самое с вариантами ответов, их может быть разное количество от вопроса к вопросу
        // конец вариантов ответов помечается как ~endansw (End answers)
        private void Questions()
        {
            while(true)
            {
                line = fileQuestions.ReadLine();

                if (line.EndsWith("~endque"))
                {
                    Console.WriteLine(line.Substring(0, line.Length - 7) + "\n"); // удаление метки конца вопроса
                    break;
                }

                else
                    Console.WriteLine(line);
            }

            for (int i = 0; ; i++)
            {
                // Вот тут начинаются проблемы со считыванием файла ТОЛЬКО с вопросами
                // поэтому приходится делать дополнительную проверку :(
                line = fileQuestions.ReadLine();
                if (line == null || line.EndsWith("~endque"))
                    break;

                // Считывание построчно вариантов ответов в массив (объяснение в методе Answer)
                // т.к. количество вариантов ответов может быть разным для каждого вопроса то
                // приходится заводить переменную счетчик для их подсчета
                if (line.EndsWith("~endansw"))
                {
                    variants[i] = line.Substring(0, line.Length - 8);
                    Console.WriteLine(variants[i]);
                    variantsCount++; break;
                }

                else
                {
                    variants[i] = line;
                    Console.WriteLine(line);
                    variantsCount++;
                }
            }
        }


        // Пользователю разрешено вводить только цифры вариантов ответа (вводить ответ полностью неудобно, да и вероятность ошибиться выше)
        // в связи с этим, для лучшей наглядности результата сдачи теста
        // в зависимости от введенной цифры варианта ответа в массив ответов пользователя
        // присваивается вся строка с вариантом ответа (не просто цифра, а сам ответ) из массива
        // с вариантами ответов из текущего вопроса variants[]
        private void Answer()
        {
            Console.Write("\nВаш ответ: ");

            string answer = Console.ReadLine();


            // Избавиться от этого ужаса
            // вместо цифры варианта - ответу пользователю присваивается полноценный ответ:
            // (было - "3", станет - "3) protected internal.")
            // количетво возможных вариантов от вопроса к вопросу отличается
            // приходится строить эту лестницу со switch :(
            if (variantsCount <= 4)
            {
                switch (answer)
                {
                    case "1": answer = variants[0]; break;
                    case "2": answer = variants[1]; break;
                    case "3": answer = variants[2]; break;
                    case "4": answer = variants[3]; break;
                    default: answer = "\"Некорректный ввод данных\""; break;
                }
            }
            else if (variantsCount == 5)
            {
                switch (answer)
                {
                    case "1": answer = variants[0]; break;
                    case "2": answer = variants[1]; break;
                    case "3": answer = variants[2]; break;
                    case "4": answer = variants[3]; break;
                    case "5": answer = variants[4]; break;
                    default: answer = "\"Некорректный ввод данных\""; break;
                }
            }
            else if (variantsCount >= 6)
            {
                switch (answer)
                {
                    case "1": answer = variants[0]; break;
                    case "2": answer = variants[1]; break;
                    case "3": answer = variants[2]; break;
                    case "4": answer = variants[3]; break;
                    case "5": answer = variants[4]; break;
                    case "6": answer = variants[5]; break;
                    default: answer = "\"Некорректный ввод данных\""; break;
                }
            }
            else { } // Без этого опять таки не получится считывать ответы для файла с вопросами

            answers[count] = answer; // Занесли ответ в массив ответов пользователя
            count++;                 // и увеличили значение для следующего ответа

            variantsCount = 0; // Обнулим счетчик для подсчета вариантов ответов след. вопроса
        }

        private void AnswerQuestions()
        {
            string answer = Console.ReadLine();
            answers[count] = answer;
            count++;
        }

        public void GetAnswers()
        {
            Console.WriteLine("Ваши ответы: ");

            for(int i = 0; i < numberQuestions; i++)
            {
                Console.Write((i + 1) + ") ");
                Console.WriteLine(answers[i]);
            }
        }


        // Здесь выводится результат сдачи теста
        // заново считываем файл с вопросами на этот раз игнорируя варианты ответов 
        // сравниваем вариант ответа пользователя с правильным ответом 
        // если ответы совпадают выводим оба ответа зеленым, иначе красным
        // подсчитываем количество правильных ответов
        public void Score(string path) // Избавиться от аргумента?
        {
            string s = ""; // Переменная для считывания строки из файла
            int i = 0; // Счетчик для подсчета количества итераций, цикл for не годится
            int count = 0; // Счетчик правильных ответов
            bool correct = false;

            string[] correctAnswers;


            // Нужно знать с какими правильными ответами сравнивать
            // поэтому смотрим какой файл с вопросами загружался
            // и исходя из этого выбираем нужный массив правильных ответов.
            // Для этого и нужен аргумент path, как обойтись без него?
            if (path == "CodeBlogTest.jn")
                correctAnswers = CorrectAnswersCodeBlog;

            else if (path == "JuniorTest.jn")
                correctAnswers = CorrectAnswersJuniorTest;

            else
                correctAnswers = CorrectAnswersQuestions;

            fileQuestions = new StreamReader(path, Encoding.Default);
            
            while(true)
            {
                if ((s = fileQuestions.ReadLine()) == null)
                    break;

                // проверка на окончание вопроса
                if (s.EndsWith("~endque"))
                {
                    if (answers[i] == correctAnswers[i])
                    {
                        count++;
                        correct = true;
                    }

                    Console.Write($"{s.Substring(0, s.Length - 7)}\n\n");

                    if (correct)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Ваш ответ: " + answers[i] + " " + "\tПравильный ответ: " + correctAnswers[i]);

                    Console.WriteLine(new string('―', 211));// "―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――");
                    Console.ForegroundColor = ConsoleColor.White;

                    while (true) // игнор вариантов ответов, нам они не нужны
                    {
                        s = fileQuestions.ReadLine();

                        if (s == null || s.EndsWith("~endansw"))
                            break;
                    }
                    i++;
                }

                else
                {
                    Console.WriteLine($"{s}");
                }
                
                correct = false;
            }

            // Здесь выводится количетво правильных ответов пользователя определенным цветом
            // в зависимости от количества правильных ответов от общего колечества вопросов
            // можно придумать иную логику, как черновой вариант метод Pika()
            Console.Write($"\nКоличество правильных ответов: ");

            if (count <= numberQuestions / 3)
                Console.ForegroundColor = ConsoleColor.DarkRed;

            else if (count > numberQuestions / 3 && count <= numberQuestions / 2)
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            else if (count > numberQuestions / 2 && count < numberQuestions)
                Console.ForegroundColor = ConsoleColor.DarkGreen;

            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(count);

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" из ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(numberQuestions);

            Console.ForegroundColor = ConsoleColor.White;

            if (count == numberQuestions) // если кол-во правильных ответов равно кол-ву вопросов
                Pika(); // бонус

            fileQuestions.Close();
        }


        // Данную функцию пришлось завести так как предыдущая не походит для выдачи результата
        // по файлу с вопросами, вариантов ответов нет, а ответ может быть довольно большим и сформулирован разными словами
        // поэтому нет смысла сверять ответы пользователя с правильными ответами (это не возможно)
        public void ScoreQuestions(string path) //Избавиться от аргумента?
        {
            string s = "";
            int i = 0;

            string[] correctAnswers = CorrectAnswersQuestions;

            fileQuestions = new StreamReader(path, Encoding.Default);

            while (true)
            {
                if ((s = fileQuestions.ReadLine()) == null)
                    break;

                if (s.EndsWith("~endque"))
                {
                    Console.Write($"{s.Substring(0, s.Length - 7)}\n\n");

                    Console.WriteLine("Ваш ответ: " + answers[i] + " " + "\tПравильный ответ: " + correctAnswers[i]);

                    Console.WriteLine("―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――");

                    i++;
                }

                else
                {
                    Console.WriteLine($"{s}");
                }
            }

            fileQuestions.Close();
        }


        // Поздравление об успешной сдаче теста
        // (черновой вариант)
        private void Pika()
        {
            Console.WriteLine("\n\n\n\n\t\t\t\tПоздравляем! Вы успешно сдали тест ответив правильно на все вопросы! Таким результатом может похвастаться далеко не каждый новичок! :)");
            Console.WriteLine("\t\tВы можете смело идти пробовать свои силы на настоящих собеседованиях! И помните, Вас будут оценивать не только по уму и знаниям, но также и по манерам напару с внешним видом! ");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t(Результаты теста можно посмотреть выше)\n\n\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\tУдачи!!!\n\n\n\n\n");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("####&&&&&((((((((((#####%%###########################################%/////////////////////////////");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("####&&&&&&((((((#######%%##########################################%///////((((((//////((//////((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("###%%&&&&***,&(########%%##########################################%%///////(((((((((((((/(//((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("##%%//&&&***,,,,,&%#######%###########################################%//////((((((//(///(/////////");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("##%(///&&%**,,,,,,,,####%%##########################################%//////((((/(/(///////////////(");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("#%%(////&&***,,,,,,,,,/#%%##########################################%%//////////(////////////(&&,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%(//////&&/**,,,,,,,,,,,#&%###########################################%/////////(/(((((((/&&/,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%#(//////(&//*,,,,,,,,,,,,,,#########################################%%/////((((((((&&%,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%((((((((((&//*,,,,,,,,,,,,,,,,#######################################%#9((((((&&*,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("#######(((((&///*,,,,,,,,,,,,,,,,######################################%((((&*,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("#########((((&(//*,,,,,,,,,,,,,,,,,&%####################################&&%,,,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("###########((##&//*,,,,,,,,,,,,,,,,,,*#############&&&&&&&&&%##&&&&&&/,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("################&%/**,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("##################&***,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("###################&&**,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&###");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%####################&***,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,**######");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%#%%%#####%###########&&**,%%*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,***########");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%%#######&&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,****(##########");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%####&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,***#############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%###&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,/##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%###&*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%###%%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*(%&*,,,,,,,,,,,,**##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%%%####&,,,,,,,,,/&/ ,&,,,,,,,,,,,,,,,,,,,,,,,,#&   .&&%,,,,,,,,,,,,*%##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%#####%%,,,,,,,,,&&  ,&&&/,,,,,,,,,,,,,,,,,,,,,,,&&   &&&&*,,,,,,,,,,,,*######((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("&&&&&&&&%%%%#########&,,,,,,,,,,%&&%&&&&/,,,,,,,,,,,,,,,,,,,,,,,*&&%&&&&(,,,,,,,,,,,,,*####((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("&&&&&&&&&&%%%########&,,,,,,,,,,,,/%&&&%*,,,,,,,,,,,,,,,,,,,,,,,,,*((/*,,,,,,,,,,,,,,,,*&((((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("&&&&&&&&&&&%%#######&*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*&((((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("&&&&&&&&&&%%########&,,,,,,,,,,,,,,,,,,,,,,,,,,%%%%%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*%((((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("&&&&&&&&&&%%#######&*****,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*//*,,,,,,,,/%(((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%&&&&%%%%#########&((((((##*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,##(((((((,,,,,,*&(((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("###################(((((((((#,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,(((((((((((/,,,,*(&((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("####%%%###########&((((((((((,,,,,,,,,,,,,,,,,,,,**,,,,,,,,,,,,,,,,,,,,,((((((((((((,,,,*/&((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%#######%((((((((((*,,,,,,,,,,,,,,,,%((((/*//(/,,,,,,,,,,,,,,,((((((((((((,,,,,*/&(((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%####&*((((((((,,,,,,,,,,,,,,,,,%((*********(,,,,,,,,,,,,,,,((((((((((*,,,,,*/%#((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%%##&,,,,,,,,,,,,,,,,,,,,,,,,,,%(**********(,,,,,,,,,,,,,,,,*((((((/,,,,,,,*//&((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%%%%%%%%%%%###&*,,,,,,,,,,,,,,,,,,,,,,,,,%(/*********(,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,//##(((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("%%%%%####%%%#######&**,,,,,,,,,,,,,,,,,,,,,,,,#((*******((,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*//&(((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("#########((#((((((((&***,,,,,,,,,,,,,,,,,,,,,,,,(%##((((,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*//%#((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("((((((((((((((((((((((&//*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,////#####");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    
    }
}
