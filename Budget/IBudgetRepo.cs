using System;
using System.Collections.Generic;

namespace Budget
{
    public interface IBudgetRepo
    {
        List<Budget> GetAll();
        // Budget GetBudgetPerMonth(DateTime dateTime);
    }
}