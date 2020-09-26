using System;

namespace Budget
{
    public class BudgetService
    {
        public double Query(DateTime start , DateTime end)
        {
            if (start > end)
            {
                return 0;
            }
            return 10;
        }
    }
}