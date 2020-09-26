using System;
using System.Linq;
using NSubstitute;

namespace Budget
{
    public class BudgetService
    {
        private readonly IBudgetRepo _repo;

        public BudgetService(IBudgetRepo repo)
        {
            _repo = repo;
        }

        public double Query(DateTime start , DateTime end)
        {
            if (start > end)
            {
                return 0;
            }

            var budgets = _repo.GetAll();
            if (!budgets.Any())
            {
                return 0;
            }

            var totalBudget = 0;
            foreach (var budget in budgets)
            {
                if (budget.GetFirstDate() >= start && budget.GetFirstDate() <= end)
                {
                    totalBudget += budget.Amount / (DateTime.DaysInMonth(start.Year, start.Month)) * ((end - start).Days + 1);
                }
            }

            return totalBudget;
        }
        
        
    }
}