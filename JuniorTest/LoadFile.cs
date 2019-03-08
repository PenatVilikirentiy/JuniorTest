using System;
using System.IO;
using System.Text;

namespace JuniorTest
{
    public class LoadFile
    {
        private StreamReader fileQuestions;
        private StreamReader fileVariants;
        private string[] answers;
        private string[] variants;
        private readonly string[] CorrectAnswersJuniorTest = { "5) Что за чушь.", "1) Тут тоже самое.", "3) Конец." };
        private readonly string[] CorrectAnswersCodeBlog = { "5) Что за чушь.", "1) Тут тоже самое.", "3) Конец." };
        private readonly string[] CorrectAnswersQuestions = { };
        private int count = 0, numberQuestions = 0;
        private string line;
        private int variantsCount = 0;

        public LoadFile(string pathQuestions, string pathVariants, int numbers) // убрать второй аргумент и сделать проверку с if ?
                                                                                // так получится избежать загрузки файла с вариантами
        {
            numberQuestions = numbers;
            answers = new string[numbers];
            variants = new string[10]; // const
            fileQuestions = new StreamReader(pathQuestions, Encoding.Default);
            fileVariants = new StreamReader(pathVariants, Encoding.Default);
        }

        public LoadFile(string pathQuestions, int numbers)
        {
            numberQuestions = numbers;
            answers = new string[numbers];
            variants = new string[10]; // const
            fileQuestions = new StreamReader(pathQuestions, Encoding.Default);
        }

        public void Start()
        {
            Console.Clear();

            for (int i = 0; i < numberQuestions; i++)
            {
                Questions();
                Variants(); // объединить обратно вопросы с вариантами и добавить меток на окончание вопроса и вариантов ответа?
                Answer();
                Console.Clear();
            }

            fileVariants.Close();
            fileQuestions.Close();
        }


        private void Questions()
        {
            while(true)
            {
                line = fileQuestions.ReadLine();

                if (line.EndsWith("~endque"))
                {
                    Console.WriteLine(line.Substring(0, line.Length - 7) + "\n");
                    break;
                }

                else
                    Console.WriteLine(line);
            }
        }

        private void Variants()
        {
            int i = 0;
            
            while (true)
            {
                string subStr = fileVariants.ReadLine();
                

                if (subStr.EndsWith("~endque"))
                {
                    variants[i] = subStr.Substring(0, subStr.Length - 7);
                    Console.WriteLine(variants[i]); 
                    i++;
                    variantsCount++; break;
                }
                else
                {
                    variants[i] = subStr;
                    Console.WriteLine(subStr);
                    i++;
                    variantsCount++;
                }
            }
        }


        public void Answer()
        {
            Console.Write("\nВаш ответ: ");

            string answer = Console.ReadLine();

            if (variantsCount == 4) {

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
            else
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

            answers[count] = answer;

            variantsCount = 0;

            count++;
        }

        public void GetAnswers()
        {
            Console.WriteLine("Ваши ответы: ");

            for(int i = 0; i < 23; i++)
            {
                Console.Write((i + 1) + ") ");
                Console.WriteLine(answers[i]);
            }
        }

        public void Score(string path)
        {
            string s = "";
            int i = 0;
            int count = 0;
            bool correct = false;

            string[] correctAnswers;

            if (path == "CodeBlogTest.jn")
                correctAnswers = CorrectAnswersCodeBlog;

            else if (path == "JuniorTest.jn")
                correctAnswers = CorrectAnswersJuniorTest;

            else
                correctAnswers = CorrectAnswersQuestions;

            fileQuestions = new StreamReader(path, Encoding.Default);

            while (true) 
            {
                if((s = fileQuestions.ReadLine()) == null)
                break;

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

                    Console.WriteLine("―――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――――");
                    Console.ForegroundColor = ConsoleColor.White;
                    i++;
                }

                else
                {
                    Console.WriteLine($"{s}");
                }

                correct = false;
            }

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

            if (count == numberQuestions)
                Pika();
        }

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
