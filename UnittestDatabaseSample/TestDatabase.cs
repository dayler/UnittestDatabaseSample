using System;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;

namespace UnittestDatabaseSample
{
    [TestFixture]
    class TestDatabase
    {
        private const String TestSp = "p_InsertTestData";
        private const String ConnectionString = "Server=.\\SQL2008;Database=TestUnitTestDB;User Id=sa;Password=control;";

        private SqlConnection connection;

        [SetUp]
        public void SetUp()
        {
            // No op.
        }

        [TearDown]
        public void TearDown()
        {
            // No op.
        }

        [Test, Rollback]
        public void TestInsertTestData()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();

            Assert.DoesNotThrow(delegate
                {
                    using (SqlCommand command = new SqlCommand(TestSp, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@LogText", "Lelya te extraño..."));
                        command.ExecuteNonQuery();
                    }
                });

            connection.Close();
        }
    }
}
