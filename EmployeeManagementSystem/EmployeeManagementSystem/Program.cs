using EmployeeManagementSystem.Models;
using System;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{Id=1 ,Name="Harshvardhan", Age=22, Department="IT", JoinDate=new DateTime(2024,8,16), Salary=70000},
                new Employee{Id= 2,Name="Amrendra", Age=32, Department="HR", JoinDate=new DateTime(2016, 8, 15), Salary=50000},
                new Employee{Id= 3,Name="Kritish", Age=55, Department="IT", JoinDate=new DateTime(2021, 8, 15), Salary=60000},
                new Employee{Id=4 ,Name="Gaurav", Age=45, Department="Sales", JoinDate=new DateTime(2022, 7, 7), Salary=65000},
                new Employee{Id= 5,Name="Divyansh", Age=40, Department="Finance", JoinDate=new DateTime(2013, 2, 20), Salary=30000},
                new Employee{Id= 6,Name="Ayush", Age=45, Department="IT", JoinDate=new DateTime(2023, 11, 5), Salary=25000},
                new Employee{Id= 7,Name="Ambuj", Age=32, Department="HR", JoinDate=new DateTime(2024, 6, 10), Salary=20000},
                new Employee{Id=8 ,Name="Aditya", Age=22, Department="IT", JoinDate=new DateTime(2024, 1, 15), Salary=10000},
                new Employee{Id= 9,Name="Jaspreet", Age=21, Department="Sales", JoinDate=new DateTime(2021, 4, 17), Salary=80000},
                new Employee{Id= 10,Name="Amaan", Age=24, Department="Finance", JoinDate=new DateTime(2020, 6, 18), Salary=50000},
                new Employee{Id= 11,Name="Kartik", Age=26, Department="Sales", JoinDate=new DateTime(2019, 6, 18), Salary=75000},

            };
            //1
            Console.WriteLine("Employee Names and Departments");
            Console.WriteLine();
            employees.Select(emp => new { emp.Name, emp.Department })
                .ToList()
                .ForEach(employee =>
                {
                    Console.WriteLine(employee.Name+" : "+employee.Department);
                });

            Console.WriteLine("**********************************************");
            //2
            Console.WriteLine("Retrieve all employees in the \"IT\" department whose salary is above 60,000.");
            Console.WriteLine();
            employees.Where(emp=>emp.Department=="IT"&&emp.Salary>60000).ToList()
                .ForEach(emp => {
                    Console.WriteLine(emp.Name + " : " + emp.Salary);
                });
            Console.WriteLine("**********************************************");

            //3
            Console.WriteLine("Display employees ordered by their joining date.");
            Console.WriteLine();
            employees.OrderBy(emp => emp.JoinDate)
                .ToList()
                .ForEach(emp =>
                {
                    Console.WriteLine(emp.Name + " : " + emp.JoinDate.ToString("yyyy-MM-dd"));
                });
            Console.WriteLine("********************************************");

            //4
            Console.WriteLine("Display employees by descending order of their salary within each department.");
            Console.WriteLine();
            employees.OrderByDescending(employees => employees.Department)
                .ThenByDescending(emp => emp.Salary)
                .ToList()
                .ForEach(emp =>
                {
                    Console.WriteLine(emp.Name + " : " + emp.Department + " : " + emp.Salary);
                });
            Console.WriteLine("**********************************************");
            //5
            Console.WriteLine("Group employees by department and show the number of employees in each department.");
            Console.WriteLine();
            employees.GroupBy(emp => emp.Department)
                .ToList()
                .ForEach(emp =>
                {
                    Console.WriteLine(emp.Key+" : "+emp.Count());
                });
            Console.WriteLine("**********************************************");
            
            //6

            
            Console.WriteLine("List average salaries by department.");
            Console.WriteLine();
            employees.GroupBy(emp => emp.Department)
                .Select(departmentGroup => new
                {
                    Department = departmentGroup.Key,
                    AverageSalary=departmentGroup.Average(emp=>emp.Salary)
                })
                .ToList()
                .ForEach(department =>
                {
                    Console.WriteLine(department.Department+" : "+department.AverageSalary);
                });

            Console.WriteLine("**********************************************");
            

            //7
            
            Console.WriteLine("Joining with department list");
            Console.WriteLine();
            var departments = new List<(int DepartmentId, string DepartmentName)>
            {
                (1, "IT"),
                (2, "HR"),
                (3, "Finance"),
                (4, "Marketing")
            };
            employees.Join(departments, emp => emp.Department, dept => dept.DepartmentName, 
                (emp, dept) => new { emp.Name, dept.DepartmentName })
                .ToList()
                .ForEach(result =>
                {
                    Console.WriteLine(result.Name + " : " + result.DepartmentName);
                });

            Console.WriteLine("**********************************************");
            

            //8
            Console.WriteLine();
            Console.WriteLine($"Total no of employees: {employees.Count}");
            Console.WriteLine("********************************************");

            //9
            Console.WriteLine();
            Console.WriteLine($"Total sal exp: {employees.Sum(emp => emp.Salary)}");
            Console.WriteLine("********************************************");
            //10
            Console.WriteLine();
            Console.WriteLine($"Average Age of Employees: {employees.Average(emp => emp.Age)}");
            Console.WriteLine("********************************************");
            //11
            Console.WriteLine("Find the employee with the highest salary");
            Console.WriteLine();
            var highestSalary = employees.Max(emp => emp.Salary);
            var highestPaidEmployee = employees.FirstOrDefault(emp => emp.Salary == highestSalary);
            Console.WriteLine(highestPaidEmployee.Name+" has the highest salary");
            Console.WriteLine("********************************************");

            //12
            Console.WriteLine("Find the minimum salary in the \"HR\" department.");
            Console.WriteLine();
            var minSalaryHR = employees.Where(emp => emp.Department == "HR").Min(emp => emp.Salary);
            Console.WriteLine(minSalaryHR+" is the minimum salary in hr dept");
            Console.WriteLine("********************************************");

            //13
            Console.WriteLine("Show the top 3 highest-paid employees and then skip the first 3 and show the next 3 highest-paid.");
            Console.WriteLine();
            employees.OrderByDescending(employees => employees.Salary)
                .Take(3)
                .ToList()
                .ForEach(emp => {
                    Console.WriteLine(emp.Name+" : "+emp.Salary);
                });
            Console.WriteLine();
            employees.OrderByDescending(employees => employees.Salary)
               .Skip(3)
               .Take(3)
               .ToList()
               .ForEach(emp => {
                   Console.WriteLine(emp.Name + " : " + emp.Salary);
               });
            Console.WriteLine("*********************************************");

            //14
            Console.WriteLine("Check if any employee is under 25 years of age.");
            Console.WriteLine();
            if (employees.Any(emp => emp.Age < 25))
            {
                Console.WriteLine("Yes, there are employees whose age is under 25");
                
            }
            else
            {
                Console.WriteLine("No Employees under 25");
            }
            Console.WriteLine("*********************************************");
            //15
            Console.WriteLine("Ensure all employees have a salary above 30,000.");
            Console.WriteLine();
            if (employees.All(emp => emp.Age > 30000))
            {
                Console.WriteLine("Yes, all emp have salary above 30000");

            }
            else
            {
                Console.WriteLine("No, all emp doesnt have sal above 30000");
            }
            Console.WriteLine("*********************************************");
            //16
            Console.WriteLine("List all unique departments ");
            Console.WriteLine();
            List<string> departmentNames = new List<string>()
            {
                "IT", "HR", "Finance", "Sales", "IT", "HR", "IT", "Finance", "Sales"
            };
            departmentNames.Distinct()
                .ToList()
                .ForEach(department =>
                {
                    Console.WriteLine(department);
                });
        }
    }
}
