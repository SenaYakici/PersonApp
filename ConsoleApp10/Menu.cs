using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Menu 
    {
        public void MainMenu()
        {
            go:
            Department dep = new Department();
            Employee emp = new Employee();
            Console.WriteLine("Type the name of the process you want to do");
            Console.WriteLine("add person - delete person - personlist -");
            Console.WriteLine("add department- delete department - departmentList - departmentPerson");
            Console.WriteLine("leaveDate");
            string choice = Console.ReadLine().ToLower();
            //kullanıcının consol da yazdığı komuta göre aşağıda seçimlerini yönlendirdim gerekli fonksiyonlara.
            if (choice == "add person")
            {
                emp.AddPerson();
            }
            else if (choice == "delete person")
            {
               emp.DeletePerson();
            }
            else if (choice == "personlist")
            {
                emp.ListPerson();
            }
            else if (choice == "add department")
            {
                dep.AddDepartment();
            }
            else if (choice == "delete department")
            {
                dep.DeleteDepartment();
            }
            else if (choice == "departmentList")
            {
               dep.DepartmentList();
            }
            else if (choice == "departmentPerson")
            {
                dep.DepartmentPerson();
            }
            else if (choice == "leaveDate")
            {
                emp.LeaveDate();
            }
            else
            {
                Console.WriteLine("-----You entered an incorrect command.please try again------");
                goto go;
            }
        }
    }
}
