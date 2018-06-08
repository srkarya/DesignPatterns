using DPortal.Manager;
using DPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPortal.Factory.FactoryMethod
{
    public abstract class BaseEmployeeFactory
    {
        protected Employee _employee;

        public BaseEmployeeFactory(Employee employee)
        {
            _employee = employee;
        }

        public abstract IEmployeeManager Create();

        public Employee ApplySalary() {
            IEmployeeManager manager = this.Create();
            _employee.Bonus = manager.GetBonus();
            _employee.HourlyPay = manager.GetHourlyPay();
            return _employee;
        }
    }
}