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
            if (IsInvalidDateTimeRange(start , end))
            {
                return 0;
            }

            var budgets = _repo.GetAll();

            var totalBudget = 0;
            foreach (var budget in budgets)
            {
                if (start.ToString("yyyyMM") == end.ToString("yyyyMM"))
                {
                        totalBudget += CalculateBudgetAmount(start , end , budget);
                }
                else
                {
                    if (budget.YearMonth == start.ToString("yyyyMM"))
                    {
                        var lastOfMonth = new DateTime(start.Year, start.Month,DateTime.DaysInMonth(budget.GetDate().Year, budget.GetDate().Month));
                        totalBudget += CalculateBudgetAmount(start , lastOfMonth , budget); 
                    }
                    else if(budget.YearMonth == end.ToString("yyyyMM"))
                    {
                        totalBudget += budget.Amount /
                                       DateTime.DaysInMonth(budget.GetDate().Year, budget.GetDate().Month) *
                                       ((end -budget.GetDate()).Days + 1);
                    }
                    else if(budget.GetDate() >= start && budget.GetDate() <= end)
                    {
                        totalBudget += budget.Amount;
                    }
                }
            }

            return totalBudget;
        }

        private int CalculateBudgetAmount(DateTime start , DateTime end , Budget budget)
        {
            var daysInMonth = DateTime.DaysInMonth(budget.GetDate().Year, budget.GetDate().Month);
            return budget.Amount / daysInMonth * ((end - start).Days + 1);
        }

        private static bool IsInvalidDateTimeRange(DateTime start , DateTime end)
        {
            return start > end;
        }
    }
}