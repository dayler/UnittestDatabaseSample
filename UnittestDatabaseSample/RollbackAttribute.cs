using System;
using System.Transactions;
using NUnit.Framework;

namespace UnittestDatabaseSample
{
    /// <summary>
    /// Rollback Attribute wraps test execution into a transaction and cancels the transaction once the test is finished.
    /// You can use this attribute on single test methods or test classes/suites
    /// </summary>
    public class RollbackAttribute : Attribute, ITestAction
    {
        private TransactionScope transaction;

        public void BeforeTest(TestDetails testDetails)
        {
            transaction = new TransactionScope();
        }

        public void AfterTest(TestDetails testDetails)
        {
            transaction.Dispose();
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }
}
