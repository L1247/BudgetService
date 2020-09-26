using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace Budget
{
    public class BudgetServiceTests
    {
        private BudgetService _budgetService;
        private DateTime      _startDate;
        private DateTime      _endDate;
        private IBudgetRepo   _repo;

        [SetUp]
        public void Setup()
        {
            _repo          = Substitute.For<IBudgetRepo>();
            _budgetService = new BudgetService(_repo);
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

        [Test]
        public void WhenNoBudget()
        {
            List<Budget> budgets = new List<Budget>();
            _repo.GetAll().Returns(budgets);
            _startDate = new DateTime(2019, 08, 1);
            _endDate   = new DateTime(2019, 09, 1);
            AmountShouldBe(0);
        }
    }
}