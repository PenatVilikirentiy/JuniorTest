using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JuniorTest
{
    public class Loader
    {
      
        private StreamReader stream;
       
       
        private string line;
        private List<string> answers;

        public Loader()
        {
            
            stream = new StreamReader("JuniorTest.jn", Encoding.Default);
          
          

           
        }

        public Loader(string path) : base()
        {
            stream = new StreamReader(path, Encoding.Default);


        }

        public Question Load()
        {

            Question q=new Question()
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

