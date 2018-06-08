using DPortal.Manager;
using DPortal.Models;

namespace DPortal.Factory.FactoryMethod
{
    public class PermanentEmployeeFactory : BaseEmployeeFactory
    {
        public PermanentEmployeeFactory(Employee employee) : base(employee)
        {
        }

        public override IEmployeeManager Create()
        {
            PermanentEmployeeManager permanentEmployeeManager = new PermanentEmployeeManager();
            _employee.HouseAllowance = permanentEmployeeManager.GetHouseAllowance();
            return permanentEmployeeManager;
        }
    }
}