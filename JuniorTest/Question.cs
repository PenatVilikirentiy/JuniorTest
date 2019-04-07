using System.Collections.Generic;

namespace JuniorTest
{
    class Question
    {
        public  string Question{get;private set;}
        public List<string> variants{get; private set;}

        public Question(string question,param string[] variants)
        {
            Question = question;
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
