using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JuniorTest
{
    public class Load
    {
        private readonly List<string> CorrectAnswersJuniorTest = new List<string> { "b.", "2.", "9254.", "private.", "В виде структур.", "Из конструктора, либо в месте объявления поля, приравнивая ему какое-то значение.", "lock.", "System.Object", "true, false, true, true.", "Напечатает слово \"test\".", "ABC.", "IEnumerable.", "Catch Exception, Catch MyCustomException.", "10, 10, 10, 10, 10, 10, 10, 10, 10, 10.", "Чтение - О(1), запись - О(1).", "Параметр с ключевым словом out может быть не инициализирован, а параметр с ключевым словом ref обязательно должен быть инииализирован до вызова метода, который использует эти параметры.", "false, false.", "Не является ни в каком случае.", "В случае ошибки cast выбрасывает исключение InvalidCastException, а оператор as возвращает null.", "Всегда будет напечатано слово \"test\".", "Один раз при первом создании экземпляра класса или при первом обращении к статическим членам класса.", "readonly можно только в конструкторе.", "Distinct()", "Вопрос №24", "Вопрос №25", "Вопрос №26", "Вопрос №27", "Вопрос №28", "Вопрос №29", "Вопрос №30", "Вопрос №31", "Вопрос №32", "Вопрос №33", "Вопрос №34", "Вопрос №35", "Вопрос №36", "Вопрос №37", "Вопрос №38", "Вопрос №39" };
        private StreamReader stream;
        private Question Question;
        private readonly List<Question> questions;
        private string line;
        private List<string> answers;

        public Load()
        {
            stream = new StreamReader("JuniorTest.jn", Encoding.Default);
            questions = new List<Question>();
            answers = new List<string>();

            Initialization();
        }

        public Load(string path) : base()
        {
            stream = new StreamReader(path, Encoding.Default);
        }

        private void Initialization()
        {
            while (true)
            {
                Question = new Question();
                string temp = "";

                while (true)
                {
                    if ((line = stream.ReadLine()) == null)
                        return;

                    if (line.EndsWith("~endque"))
                    {
                        temp += line.Substring(0, line.Length - 7) + "\n";
                        Question.AddQuestion(temp);
                        break;
                    }

                    else
                        temp += line + "\n";
                }

                while (true)
                {
                    line = stream.ReadLine();

                    if (line.EndsWith("~endansw"))
                    {
                        Question.AddVariant(line.Substring(0, line.Length - 8) + "\n");
                        break;
                    }

                    else
                        Question.AddVariant(line);
                }

                questions.Add(Question);
            }
        }

        public void Start()
        {
            string answer;

            foreach (var question in questions)
            {
                Console.Clear();

                Console.WriteLine(question.GetQuestion());

                Console.WriteLine(question.GetVariants());
                Console.Write("\n\nВаш ответ: ");

                answer = Console.ReadLine();

                answers.Add(question.GetVariant(answer));
            }

            Score();
        }

        private void Score()
        {
            int count = 0;
            bool correct = false;

            Console.Clear();

            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i].GetQuestion());

                if (answers[i] == CorrectAnswersJuniorTest[i])
                {
                    count++;
                    correct = true;
                }

                if (correct)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Ваш ответ:        \t" + answers[i] + "\n\nПравильный ответ: \t" + CorrectAnswersJuniorTest[i]);

                Console.WriteLine(new string('―', 211));
                Console.ForegroundColor = ConsoleColor.White;

                correct = false;
            }

            Console.WriteLine($"Количество правильных ответов {count} из {answers.Count}");

            if (count == answers.Count)
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
            Console.Write("####&&&&&((((((((((#####%%###########################################%/////////////////////////////");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("####&&&&&&((((((#######%%##########################################%///////((((((//////((//////((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("###%%&&&&***,&(########%%##########################################%%///////(((((((((((((/(//((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("##%%//&&&***,,,,,&%#######%###########################################%//////((((((//(///(/////////");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("##%(///&&%**,,,,,,,,####%%##########################################%//////((((/(/(///////////////(");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("#%%(////&&***,,,,,,,,,/#%%##########################################%%//////////(////////////(&&,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%(//////&&/**,,,,,,,,,,,#&%###########################################%/////////(/(((((((/&&/,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%#(//////(&//*,,,,,,,,,,,,,,#########################################%%/////((((((((&&%,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%((((((((((&//*,,,,,,,,,,,,,,,,#######################################%#9((((((&&*,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("#######(((((&///*,,,,,,,,,,,,,,,,######################################%((((&*,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("#########((((&(//*,,,,,,,,,,,,,,,,,&%####################################&&%,,,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("###########((##&//*,,,,,,,,,,,,,,,,,,*#############&&&&&&&&&%##&&&&&&/,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("################&%/**,,,,,,,,,,,,,,,,,,*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("##################&***,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("###################&&**,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,&###");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%####################&***,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,**######");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%#%%%#####%###########&&**,%%*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,***########");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%%#######&&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,****(##########");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%%%%%####&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,***#############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%%%%%%###&,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,/##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%%%%%###&*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%%%%###%%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*(%&*,,,,,,,,,,,,**##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%%%####&,,,,,,,,,/&/ ,&,,,,,,,,,,,,,,,,,,,,,,,,#&   .&&%,,,,,,,,,,,,*%##############");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%#####%%,,,,,,,,,&&  ,&&&/,,,,,,,,,,,,,,,,,,,,,,,&&   &&&&*,,,,,,,,,,,,*######((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("&&&&&&&&%%%%#########&,,,,,,,,,,%&&%&&&&/,,,,,,,,,,,,,,,,,,,,,,,*&&%&&&&(,,,,,,,,,,,,,*####((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("&&&&&&&&&&%%%########&,,,,,,,,,,,,/%&&&%*,,,,,,,,,,,,,,,,,,,,,,,,,*((/*,,,,,,,,,,,,,,,,*&((((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("&&&&&&&&&&&%%#######&*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*&((((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("&&&&&&&&&&%%########&,,,,,,,,,,,,,,,,,,,,,,,,,,%%%%%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*%((((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("&&&&&&&&&&%%#######&*****,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*//*,,,,,,,,/%(((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%&&&&%%%%#########&((((((##*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,##(((((((,,,,,,*&(((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("###################(((((((((#,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,(((((((((((/,,,,*(&((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("####%%%###########&((((((((((,,,,,,,,,,,,,,,,,,,,**,,,,,,,,,,,,,,,,,,,,,((((((((((((,,,,*/&((((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%#######%((((((((((*,,,,,,,,,,,,,,,,%((((/*//(/,,,,,,,,,,,,,,,((((((((((((,,,,,*/&(((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%####&*((((((((,,,,,,,,,,,,,,,,,%((*********(,,,,,,,,,,,,,,,((((((((((*,,,,,*/%#((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%%##&,,,,,,,,,,,,,,,,,,,,,,,,,,%(**********(,,,,,,,,,,,,,,,,*((((((/,,,,,,,*//&((((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%%%%%%%%%%%###&*,,,,,,,,,,,,,,,,,,,,,,,,,%(/*********(,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,//##(((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("%%%%%####%%%#######&**,,,,,,,,,,,,,,,,,,,,,,,,#((*******((,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*//&(((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("#########((#((((((((&***,,,,,,,,,,,,,,,,,,,,,,,,(%##((((,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,*//%#((((");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t\t");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("((((((((((((((((((((((&//*,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,////#####");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}

