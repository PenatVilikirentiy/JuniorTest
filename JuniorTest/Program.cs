using System;
using System.Runtime.InteropServices;
using System.Text;

namespace JuniorTest
{


    class Program
    {
        const int STD_OUTPUT_HANDLE = -11;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleDisplayMode(IntPtr ConsoleHandle, uint Flags,  IntPtr NewScreenBufferDimensions);


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
            SetConsoleDisplayMode(hConsole, 1, IntPtr.Zero);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight + 400);

            Console.WriteLine("Добро пожаловать!\nДанный тест поможет Вам подготовиться к собеседованию на должность Junior/Middle Developer\nа так же проверить свои знания по языку C# и платформе .Net");
            Console.WriteLine("\nВ ответах следует вводить только цифру варианта ответа без пробелов и знаков!\nВ случае ввода некорректного значения/пустого ввода ответ будет засчитан как неправильный либо как ответ\"Я не знаю.\"");
            Console.WriteLine("Поэтому если Вы не знаете правильный ответ можете смело жать клавишу Enter. (Ничего не вводить)");
            Console.WriteLine("Честность прохождения возлагается на самого проходящего. Сдавать тест наугад не разрешается т.к. данный тест несет цель проверить Ваши текущие знания по языку C# и платформе .Net\n");
            Console.WriteLine("Иными словами жульничать смысла нет, на собеседовании ведь не сжульничаешь :)\n");

            Console.WriteLine("Вы готовы начать? y/n\n");
            string str = Console.ReadLine();
            if (str.ToLower() == "y")
            {

                LoadFile test = new LoadFile("JuniorTest.jn", "JuniorTestVariants.jn", 3);


                Console.Clear();
                Console.WriteLine("Выберите вариант теста: \n1)Тест по пройденному материалу CODE BLOG. (уроки 1 ― 30)\n2)Тест на должность Junior/Middle Developer.\n3)Вопросы для самопроверки.");
                Console.Write("\nВаш выбор: ");
                str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        {
                            test = new LoadFile("CodeBlogTest.jn", "CodeBlogTestVariants.jn", 3);
                            str = "CodeBlogTest.jn"; break;
                        }

                    case "2":
                        {
                            test = new LoadFile("JuniorTest.jn", "JuniorTestVariants.jn", 3);
                            str = "JuniorTest.jn"; break;
                        }

                    case "3":
                        {
                            test = new LoadFile("Questions.jn", 0);
                            str = "Questions.jn"; break;
                        }

                    default:
                        {
                            Console.WriteLine("\nВы ввели некорректное значение, программа будет завершена!\n");
                            Console.ReadKey();
                            Environment.Exit(0); break;
                        }
                }

                test.Start();
                test.Score(str);
                Console.ReadKey();
            }
            else if (str.ToLower() == "n")
            {
                Console.WriteLine("\nСлабак :)\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nВы ввели некорректное значение!\n\nПрограмма будет завершена!\n");
                Console.ReadKey();
            }
        }
    }
}
