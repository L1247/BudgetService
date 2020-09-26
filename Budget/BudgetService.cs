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

        public double Query(DateTime start, DateTime end)
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
                var daysInMonth = DateTime.DaysInMonth(budget.GetDate().Year, budget.GetDate().Month);
                if (start.Year == end.Year && start.Month == end.Month)
                {
                    if (budget.GetDate() >= start && budget.GetDate() <= end)
                    {
                        totalBudget += budget.Amount /
                                       daysInMonth *
                                       ((end - start).Days + 1);
                    }
                }
                else
                {
                    if (budget.GetDate() >= start)
                    {
                        var lastOfMonth = new DateTime(start.Year, start.Month,daysInMonth);
                        totalBudget += budget.Amount /
                                       daysInMonth *
                                       ((lastOfMonth - start).Days + 1);
                    }
                    else
                    {
                        totalBudget += budget.Amount /
                                       daysInMonth *
                                       ((start-budget.GetDate()).Days + 1);
                    }


                }
            }

            return totalBudget;
        }
    }
}