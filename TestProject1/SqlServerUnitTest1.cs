using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass()]
    public class SqlServerUnitTest1 : SqlDatabaseTestClass
    {

        public SqlServerUnitTest1()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction HumanResources_uspUpdateEmployeeHireInfoTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerUnitTest1));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition1;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction HumanResources_uspUpdateEmployeeLoginTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition2;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction HumanResources_uspUpdateEmployeePersonalInfoTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_uspGetBillOfMaterialsTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition4;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_uspGetEmployeeManagersTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_uspGetManagerEmployeesTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition6;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_uspGetWhereUsedProductIDTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition7;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_uspLogErrorTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition8;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_uspPrintErrorTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition9;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_uspSearchCandidateResumesTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition inconclusiveCondition10;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition notEmptyResultSetCondition1;
            this.HumanResources_uspUpdateEmployeeHireInfoTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.HumanResources_uspUpdateEmployeeLoginTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.HumanResources_uspUpdateEmployeePersonalInfoTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_uspGetBillOfMaterialsTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_uspGetEmployeeManagersTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_uspGetManagerEmployeesTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_uspGetWhereUsedProductIDTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_uspLogErrorTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_uspPrintErrorTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.dbo_uspSearchCandidateResumesTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            HumanResources_uspUpdateEmployeeHireInfoTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            HumanResources_uspUpdateEmployeeLoginTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            HumanResources_uspUpdateEmployeePersonalInfoTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            dbo_uspGetBillOfMaterialsTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition4 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            dbo_uspGetEmployeeManagersTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            dbo_uspGetManagerEmployeesTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition6 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            dbo_uspGetWhereUsedProductIDTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition7 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            dbo_uspLogErrorTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition8 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            dbo_uspPrintErrorTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition9 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            dbo_uspSearchCandidateResumesTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            inconclusiveCondition10 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.InconclusiveCondition();
            notEmptyResultSetCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.NotEmptyResultSetCondition();
            // 
            // HumanResources_uspUpdateEmployeeHireInfoTest_TestAction
            // 
            HumanResources_uspUpdateEmployeeHireInfoTest_TestAction.Conditions.Add(inconclusiveCondition1);
            resources.ApplyResources(HumanResources_uspUpdateEmployeeHireInfoTest_TestAction, "HumanResources_uspUpdateEmployeeHireInfoTest_TestAction");
            // 
            // inconclusiveCondition1
            // 
            inconclusiveCondition1.Enabled = true;
            inconclusiveCondition1.Name = "inconclusiveCondition1";
            // 
            // HumanResources_uspUpdateEmployeeLoginTest_TestAction
            // 
            HumanResources_uspUpdateEmployeeLoginTest_TestAction.Conditions.Add(inconclusiveCondition2);
            resources.ApplyResources(HumanResources_uspUpdateEmployeeLoginTest_TestAction, "HumanResources_uspUpdateEmployeeLoginTest_TestAction");
            // 
            // inconclusiveCondition2
            // 
            inconclusiveCondition2.Enabled = true;
            inconclusiveCondition2.Name = "inconclusiveCondition2";
            // 
            // HumanResources_uspUpdateEmployeePersonalInfoTest_TestAction
            // 
            HumanResources_uspUpdateEmployeePersonalInfoTest_TestAction.Conditions.Add(inconclusiveCondition3);
            resources.ApplyResources(HumanResources_uspUpdateEmployeePersonalInfoTest_TestAction, "HumanResources_uspUpdateEmployeePersonalInfoTest_TestAction");
            // 
            // inconclusiveCondition3
            // 
            inconclusiveCondition3.Enabled = true;
            inconclusiveCondition3.Name = "inconclusiveCondition3";
            // 
            // dbo_uspGetBillOfMaterialsTest_TestAction
            // 
            dbo_uspGetBillOfMaterialsTest_TestAction.Conditions.Add(inconclusiveCondition4);
            dbo_uspGetBillOfMaterialsTest_TestAction.Conditions.Add(notEmptyResultSetCondition1);
            resources.ApplyResources(dbo_uspGetBillOfMaterialsTest_TestAction, "dbo_uspGetBillOfMaterialsTest_TestAction");
            // 
            // inconclusiveCondition4
            // 
            inconclusiveCondition4.Enabled = true;
            inconclusiveCondition4.Name = "inconclusiveCondition4";
            // 
            // dbo_uspGetEmployeeManagersTest_TestAction
            // 
            dbo_uspGetEmployeeManagersTest_TestAction.Conditions.Add(inconclusiveCondition5);
            resources.ApplyResources(dbo_uspGetEmployeeManagersTest_TestAction, "dbo_uspGetEmployeeManagersTest_TestAction");
            // 
            // inconclusiveCondition5
            // 
            inconclusiveCondition5.Enabled = true;
            inconclusiveCondition5.Name = "inconclusiveCondition5";
            // 
            // dbo_uspGetManagerEmployeesTest_TestAction
            // 
            dbo_uspGetManagerEmployeesTest_TestAction.Conditions.Add(inconclusiveCondition6);
            resources.ApplyResources(dbo_uspGetManagerEmployeesTest_TestAction, "dbo_uspGetManagerEmployeesTest_TestAction");
            // 
            // inconclusiveCondition6
            // 
            inconclusiveCondition6.Enabled = true;
            inconclusiveCondition6.Name = "inconclusiveCondition6";
            // 
            // dbo_uspGetWhereUsedProductIDTest_TestAction
            // 
            dbo_uspGetWhereUsedProductIDTest_TestAction.Conditions.Add(inconclusiveCondition7);
            resources.ApplyResources(dbo_uspGetWhereUsedProductIDTest_TestAction, "dbo_uspGetWhereUsedProductIDTest_TestAction");
            // 
            // inconclusiveCondition7
            // 
            inconclusiveCondition7.Enabled = true;
            inconclusiveCondition7.Name = "inconclusiveCondition7";
            // 
            // dbo_uspLogErrorTest_TestAction
            // 
            dbo_uspLogErrorTest_TestAction.Conditions.Add(inconclusiveCondition8);
            resources.ApplyResources(dbo_uspLogErrorTest_TestAction, "dbo_uspLogErrorTest_TestAction");
            // 
            // inconclusiveCondition8
            // 
            inconclusiveCondition8.Enabled = true;
            inconclusiveCondition8.Name = "inconclusiveCondition8";
            // 
            // dbo_uspPrintErrorTest_TestAction
            // 
            dbo_uspPrintErrorTest_TestAction.Conditions.Add(inconclusiveCondition9);
            resources.ApplyResources(dbo_uspPrintErrorTest_TestAction, "dbo_uspPrintErrorTest_TestAction");
            // 
            // inconclusiveCondition9
            // 
            inconclusiveCondition9.Enabled = true;
            inconclusiveCondition9.Name = "inconclusiveCondition9";
            // 
            // dbo_uspSearchCandidateResumesTest_TestAction
            // 
            dbo_uspSearchCandidateResumesTest_TestAction.Conditions.Add(inconclusiveCondition10);
            resources.ApplyResources(dbo_uspSearchCandidateResumesTest_TestAction, "dbo_uspSearchCandidateResumesTest_TestAction");
            // 
            // inconclusiveCondition10
            // 
            inconclusiveCondition10.Enabled = true;
            inconclusiveCondition10.Name = "inconclusiveCondition10";
            // 
            // HumanResources_uspUpdateEmployeeHireInfoTestData
            // 
            this.HumanResources_uspUpdateEmployeeHireInfoTestData.PosttestAction = null;
            this.HumanResources_uspUpdateEmployeeHireInfoTestData.PretestAction = null;
            this.HumanResources_uspUpdateEmployeeHireInfoTestData.TestAction = HumanResources_uspUpdateEmployeeHireInfoTest_TestAction;
            // 
            // HumanResources_uspUpdateEmployeeLoginTestData
            // 
            this.HumanResources_uspUpdateEmployeeLoginTestData.PosttestAction = null;
            this.HumanResources_uspUpdateEmployeeLoginTestData.PretestAction = null;
            this.HumanResources_uspUpdateEmployeeLoginTestData.TestAction = HumanResources_uspUpdateEmployeeLoginTest_TestAction;
            // 
            // HumanResources_uspUpdateEmployeePersonalInfoTestData
            // 
            this.HumanResources_uspUpdateEmployeePersonalInfoTestData.PosttestAction = null;
            this.HumanResources_uspUpdateEmployeePersonalInfoTestData.PretestAction = null;
            this.HumanResources_uspUpdateEmployeePersonalInfoTestData.TestAction = HumanResources_uspUpdateEmployeePersonalInfoTest_TestAction;
            // 
            // dbo_uspGetBillOfMaterialsTestData
            // 
            this.dbo_uspGetBillOfMaterialsTestData.PosttestAction = null;
            this.dbo_uspGetBillOfMaterialsTestData.PretestAction = null;
            this.dbo_uspGetBillOfMaterialsTestData.TestAction = dbo_uspGetBillOfMaterialsTest_TestAction;
            // 
            // dbo_uspGetEmployeeManagersTestData
            // 
            this.dbo_uspGetEmployeeManagersTestData.PosttestAction = null;
            this.dbo_uspGetEmployeeManagersTestData.PretestAction = null;
            this.dbo_uspGetEmployeeManagersTestData.TestAction = dbo_uspGetEmployeeManagersTest_TestAction;
            // 
            // dbo_uspGetManagerEmployeesTestData
            // 
            this.dbo_uspGetManagerEmployeesTestData.PosttestAction = null;
            this.dbo_uspGetManagerEmployeesTestData.PretestAction = null;
            this.dbo_uspGetManagerEmployeesTestData.TestAction = dbo_uspGetManagerEmployeesTest_TestAction;
            // 
            // dbo_uspGetWhereUsedProductIDTestData
            // 
            this.dbo_uspGetWhereUsedProductIDTestData.PosttestAction = null;
            this.dbo_uspGetWhereUsedProductIDTestData.PretestAction = null;
            this.dbo_uspGetWhereUsedProductIDTestData.TestAction = dbo_uspGetWhereUsedProductIDTest_TestAction;
            // 
            // dbo_uspLogErrorTestData
            // 
            this.dbo_uspLogErrorTestData.PosttestAction = null;
            this.dbo_uspLogErrorTestData.PretestAction = null;
            this.dbo_uspLogErrorTestData.TestAction = dbo_uspLogErrorTest_TestAction;
            // 
            // dbo_uspPrintErrorTestData
            // 
            this.dbo_uspPrintErrorTestData.PosttestAction = null;
            this.dbo_uspPrintErrorTestData.PretestAction = null;
            this.dbo_uspPrintErrorTestData.TestAction = dbo_uspPrintErrorTest_TestAction;
            // 
            // dbo_uspSearchCandidateResumesTestData
            // 
            this.dbo_uspSearchCandidateResumesTestData.PosttestAction = null;
            this.dbo_uspSearchCandidateResumesTestData.PretestAction = null;
            this.dbo_uspSearchCandidateResumesTestData.TestAction = dbo_uspSearchCandidateResumesTest_TestAction;
            // 
            // notEmptyResultSetCondition1
            // 
            notEmptyResultSetCondition1.Enabled = true;
            notEmptyResultSetCondition1.Name = "notEmptyResultSetCondition1";
            notEmptyResultSetCondition1.ResultSet = 1;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void HumanResources_uspUpdateEmployeeHireInfoTest()
        {
            SqlDatabaseTestActions testActions = this.HumanResources_uspUpdateEmployeeHireInfoTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void HumanResources_uspUpdateEmployeeLoginTest()
        {
            SqlDatabaseTestActions testActions = this.HumanResources_uspUpdateEmployeeLoginTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void HumanResources_uspUpdateEmployeePersonalInfoTest()
        {
            SqlDatabaseTestActions testActions = this.HumanResources_uspUpdateEmployeePersonalInfoTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void dbo_uspGetBillOfMaterialsTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_uspGetBillOfMaterialsTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void dbo_uspGetEmployeeManagersTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_uspGetEmployeeManagersTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void dbo_uspGetManagerEmployeesTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_uspGetManagerEmployeesTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void dbo_uspGetWhereUsedProductIDTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_uspGetWhereUsedProductIDTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void dbo_uspLogErrorTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_uspLogErrorTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void dbo_uspPrintErrorTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_uspPrintErrorTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void dbo_uspSearchCandidateResumesTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_uspSearchCandidateResumesTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions HumanResources_uspUpdateEmployeeHireInfoTestData;
        private SqlDatabaseTestActions HumanResources_uspUpdateEmployeeLoginTestData;
        private SqlDatabaseTestActions HumanResources_uspUpdateEmployeePersonalInfoTestData;
        private SqlDatabaseTestActions dbo_uspGetBillOfMaterialsTestData;
        private SqlDatabaseTestActions dbo_uspGetEmployeeManagersTestData;
        private SqlDatabaseTestActions dbo_uspGetManagerEmployeesTestData;
        private SqlDatabaseTestActions dbo_uspGetWhereUsedProductIDTestData;
        private SqlDatabaseTestActions dbo_uspLogErrorTestData;
        private SqlDatabaseTestActions dbo_uspPrintErrorTestData;
        private SqlDatabaseTestActions dbo_uspSearchCandidateResumesTestData;
    }
}
