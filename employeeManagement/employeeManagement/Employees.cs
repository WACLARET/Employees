using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using employeeManagement.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace employeeManagement
{
    public class Employees
    {
        readonly Dictionary<string, List<string>> _dEmployees = new Dictionary<string, List<string>>();
        private List<Emp_Data> _lEmployees = new List<Emp_Data>();
        public List<Emp_Data> LstEmployees => _lEmployees;




        public Employees(String[] csvFile)
        {
            ProcessCsv(csvFile);

           
        }

        public void ProcessCsv(string[] csvFile)
        {

            int ceoCount = 0;//keep count of ceos


            foreach (var item in csvFile)
            {
                try
                {
                    var splitCsv= item.Split(',');
                     var emp = new Emp_Data();
                    emp.employee_Id = splitCsv[0];

                    if (splitCsv[1].Equals(""))
                    {
                       // Manager_Id = "";
                        ceoCount++;
                        //Managers are more than one throws Exception
                        if (ceoCount > 1)
                        {
                            Console.WriteLine("Company Ceo Can not be more than one");
                        }
                    }
                    else
                    {
                        emp.Manager_Id = splitCsv[1];
                    }


                    long salary;
                    var isvalid = Int64.TryParse(splitCsv[2], out salary);
                    //is salary a valid number?
                    if (isvalid)
                    {
                        //valid salary should be greater than 0
                        if (salary > 0)
                        {
                            emp.Emp_Salary = salary;
                        }
                        else
                        {
                            Console.WriteLine("Salary can not have a negative value");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please Check salary column correct values");
                       
                    }

                    _lEmployees.Add(emp);

                    if (splitCsv[0] != "")
                    {
                            var value = _dEmployees[emp.employee_Id];

                            if (value.Count() > 1)
                            {
                                Console.WriteLine("Employee should have only one manager");
                            }
                        
                    }


                }
                catch (Exception ex)
                {
                    //Data is not formed well. clear list of employees and exit
                    _lEmployees.Clear();
                    Console.WriteLine(ex.Message);
                    return;
                }
                //catch (Exception ex)
                //{//Data is not formed well. clear list of employees and exit
                //    _lstEmployees.Clear();
                //    Console.WriteLine(ex.Message);
                //    return;
                //}
            }

            //Verify That their is manager
            if (ceoCount != 1)
            {
                Console.WriteLine("There is no Manager identified check again the dataset");
                _lEmployees.Clear();
            }
        }

        public List<String> getEmployee(String employeeId)
        {
            return _dEmployees[employeeId];
        }

        public long getSalaryBudget(String manager)
        {
            long salaryBudget = 0;
            try
            {
               
                HashSet<String> visited = new HashSet<String>();
                Stack<String> stack = new Stack<String>();
                stack.Push(manager);
                while (stack.Count != 0)
                {
                    String employeeId = stack.Pop();
                    if (!visited.Contains(employeeId))
                    {
                        visited.Add(employeeId);
                        foreach (String v in getEmployee(employeeId))
                        {
                            stack.Push(v);
                        }
                    }
                }

                if (visited.Count == 0) return salaryBudget;
                foreach (var id in visited)
                {
                    salaryBudget += LookUp(id).Emp_Salary;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("salary budget not found", ex);
            }

            return salaryBudget;
        }


        public Emp_Data LookUp(string empId)
        {
            foreach (Emp_Data emp in _lEmployees)
            {
                if (emp.employee_Id.Equals(empId))
                {
                    return emp;
                }
            }

            return null;
        }

    }
}
