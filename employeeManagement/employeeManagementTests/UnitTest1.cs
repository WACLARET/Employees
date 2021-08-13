using System;
using System.IO;
using employeeManagement;
using employeeManagement.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace employeeManagementTests
{
   

    [TestClass]
    public class employeeManagementTests
    {
        private Employees _employees;


        string[] GetData(String path)
        {

            return File.ReadAllLines(path);
        }

      

        [TestMethod]
        public void Invalid_Salary()
        {
            Employees h2 = new Employees(GetData(@"test2.csv"));
            Assert.IsFalse(h2.LstEmployees.Contains(new Emp_Data
            { employee_Id = "Employee5" }));
            Assert.IsFalse(h2.LstEmployees.Contains(new Emp_Data
            { employee_Id = "Employee2" }));

            Assert.AreEqual(0, h2.LstEmployees.Count);

        }

        [TestMethod]
        public void Manager_More_Than_Three()
        {
            Employees h = new Employees(GetData(@"test3.csv"));
            Assert.IsFalse(h.LstEmployees.Contains(new Emp_Data
            { employee_Id = "Employee5" }));
            Assert.IsFalse(h.LstEmployees.Contains(new Emp_Data
            { employee_Id = "Employee1" }));
            Assert.AreEqual(0, h.LstEmployees.Count);

        }

        [TestMethod]
        public void Negative_Salary()
        {
            Employees h = new Employees(GetData(@"test4.csv"));
            Assert.IsFalse(h.LstEmployees.Contains(new Emp_Data
            { employee_Id = "Employee5" }));
            Assert.AreEqual(0, h.LstEmployees.Count);
        }

        [TestMethod]
        public void No_Manager_Record()
        {
            Employees h = new Employees(GetData(@"test5.csv"));
            Assert.AreEqual(0, h.LstEmployees.Count);
        }
    }
}
