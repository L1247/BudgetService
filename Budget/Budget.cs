
using System;

namespace Budget
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int    Amount    { get; set; }
        
        public DateTime GetDateTime()
        {
            var dateTime = Convert.ToDateTime(YearMonth);
            Console.WriteLine(dateTime);
            return dateTime;
        } 
    }
}