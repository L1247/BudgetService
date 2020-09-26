
using System;
using System.Globalization;

namespace Budget
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int    Amount    { get; set; }
        
        public DateTime GetDate()
        {
            var dateTime = DateTime.ParseExact($"{YearMonth}", "yyyyMM", CultureInfo.InvariantCulture);
            return dateTime;
        } 
    }
}