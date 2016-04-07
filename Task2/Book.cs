using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Book
    {
        public int Pages{get;set;}
        public Book(int pages)
        {
            if (pages < 0)
                throw new ArgumentException("count of pages below zero");
            this.Pages = pages;
        }
        public override string ToString()
        {
            return Pages.ToString();
        }

    }
}
