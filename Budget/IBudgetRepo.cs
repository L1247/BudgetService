
using System.Collections.Generic;

namespace Budget
{
    interface IBudgetRepo
    {
        List<Budget> GetAll();
    }
}