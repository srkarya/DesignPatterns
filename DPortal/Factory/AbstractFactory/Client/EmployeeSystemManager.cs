using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPortal.Factory.AbstractFactory
{
    public class EmployeeSystemManager
    {
        IComputerFactory _computerFactory;

        public EmployeeSystemManager(IComputerFactory computerFactory)
        {
            _computerFactory = computerFactory;
        }

        public string GetSystemDetails()
        {
            IBrand brand = _computerFactory.Brand();
            IProcessor processor = _computerFactory.Processor();
            ISystemType systemType = _computerFactory.SystemType();
            return string.Format("{0} {1} {2}", brand.GetBrand(), processor.GetProcessor(), systemType.GetSystemType());
        }
    }
}