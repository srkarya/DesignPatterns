using DPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPortal.Factory.AbstractFactory
{
    public class EmployeeSystemFactory
    {
        public IComputerFactory Create(Employee employee)
        {
            IComputerFactory computerFactory;
            switch (employee.EmployeeTypeId)
            {
                case 1:
                    if (employee.JobDesc.Contains("Manager"))
                    {
                        computerFactory = new MacLaptopFactory();
                    }
                    else
                    {
                        computerFactory = new MacFactory();
                    }
                    break;
                case 2:
                    if (employee.JobDesc.Contains("Manager"))
                    {
                        computerFactory = new DellLaptopFactory();
                    }
                    else
                    {
                        computerFactory = new DellFactory();
                    }
                    break;
                default:
                    computerFactory = null;
                    break;
            }

            return computerFactory;
        }
    }
}