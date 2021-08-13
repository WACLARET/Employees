using System;
using System.Collections.Generic;
using System.Text;

namespace employeeManagement.Helpers
{
    public class Emp_Data
    {
        private string id, managerId = "";
        private long salary = 0;

        public string employee_Id
        {
            get => id;
            set => id = value;
        }

        public string Manager_Id
        {
            get => managerId;
            set => managerId = value;
        }

        public long Emp_Salary
        {
            get => salary;
            set => salary = value;
        }


    }
}
