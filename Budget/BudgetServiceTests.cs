using System;
using NUnit.Framework;

namespace Budget
{
    public class BudgetServiceTests
    {
        private BudgetService _budgetService;
        private DateTime      _startDate;
        private DateTime      _endDate;

        [SetUp]
        public void Setup()
        {
            _budgetService = new BudgetService();
        }

        [Test]
        public void WhenEndDateGreaterThanStartDate()
        {
            _startDate = new DateTime(2020, 1, 1);
            _endDate   = new DateTime(2019, 1, 1);
            AmountShouldBe(0);
        }

        private void AmountShouldBe(double expected)
        {
            var amount = _budgetService.Query(_startDate , _endDate);
            Assert.AreEqual(expected, amount );
        }
    }
}