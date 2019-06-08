using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookIndex
{
    public class Index
    {
        public string Word;
        public List<int> Pages = new List<int>();

        public Index(string word, List<int> pages)
        {
            Word = word.ToLower();
            Pages = pages;
        }

        public void PrintInfo()
        {
            Pages.Sort();
            Console.Write(Word + " - ");
            for(int i = 0; i < Pages.Count; i++)
            {
                if(i != Pages.Count - 1)
                {
                    Console.Write($"{Pages.ElementAt(i)}, ");
                }
                else
                {
                    Console.WriteLine(Pages.ElementAt(i));
                }
            }
        }
        public override string ToString()
        {
            string outString = Word + " ";
            foreach(int i in Pages)
            {
                outString += i.ToString() + " ";
            }
            return outString;
        }
    }
}
