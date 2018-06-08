using DPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPortal.Factory.FactoryMethod
{
    public class EmployeeManagerFactory
    {
        public BaseEmployeeFactory CreateFactory(Employee employee)
        {
            BaseEmployeeFactory employeeManager;
            switch (employee.EmployeeTypeId)
            {
                case 1:
                    employeeManager = new PermanentEmployeeFactory(employee);
                    break;
                case 2:
                    employeeManager = new ContractEmployeeFactory(employee);
                    break;
                default:
                    employeeManager = null;
                    break;
            }

            return employeeManager;
        }
    }
}