using System.Collections.Generic;

namespace JuniorTest
{
    class Question
    {
        string question;
        List<string> variants;

        public Question()
        {
            question = "";
            variants = new List<string>();
        }

        public void AddQuestion(string question)
        {
            this.question = question;
        }

        public void AddVariant(string variant)
        {
            variants.Add(variant);
        }

        public string GetVariant(string answer)
        {
            if (int.TryParse(answer, out int index) && (index > 0 && index <= variants.Count))
                return variants[index - 1].Substring(3  );
            else
                return "Некорректный ввод данных";
        }

        public string GetQuestion()
        {
            return question;
        }

        public string GetVariants()
        {
            string var = "";

            foreach(var variant in variants)
            {
                var += variant + "\n";
            }

            return var;
        }
    }
}
