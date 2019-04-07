using System.Collections.Generic;

namespace JuniorTest
{
    class Question
    {
        public  string question{get;private set;}
        public List<string> variants{get; private set;}

        public Question(string question,params string[] variants)
        {
            this.question = question;
           this.variants =new List<string>(variants);
        }

       

        public void AddVariant(string variant)
        {
            variants.Add(variant);
        }

        public string GetVariant(int index)
        {
            return variants[index];

        }

       

        
    }
}
