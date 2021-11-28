using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 購物網站MVC_Demo.Services
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public int MaxPage { get; set; }
        public int ItemCount { 
            get { return 5; }
            private set { } 
        }
        public Paging()
        {
            CurrentPage = 1;
        }
        public Paging(int currentPage)
        {
            CurrentPage = currentPage;
        }
        public void GeneratePage(int total)
        {
            MaxPage = total / ItemCount + (total % ItemCount > 0 ? 1 : 0);
            if (ItemCount < 1)
                ItemCount = 1;
            if (CurrentPage < 1)
                CurrentPage = 1;
            if (MaxPage < CurrentPage)
                MaxPage = CurrentPage;
            if (MaxPage == 0)
            { CurrentPage = 1; }
        }
    }
}