using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DPortal.Manager;
using DPortal.Models;

namespace DPortal.Factory.FactoryMethod
{
    public class ContractEmployeeFactory : BaseEmployeeFactory
    {
        public ContractEmployeeFactory(Employee employee) : base(employee)
        {
        }

        public override IEmployeeManager Create()
        {
            ContractEmployeeManager contractEmployeeManager = new ContractEmployeeManager();
            _employee.MedicalAllowance = contractEmployeeManager.GetMedicalAllowance();
            return contractEmployeeManager;
        }
    }
}