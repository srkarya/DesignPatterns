using DPortal.Manager;

namespace DPortal.Factory
{
    public class EmployeeManagerFactory
    {
        public EmployeeManagerFactory()
        {
        }

        public IEmployeeManager GetEmployeeManager(int employeeId)
        {
            IEmployeeManager employeeManager = null;

            switch (employeeId)
            {
                case 1:
                    employeeManager = new PermanentEmployeeManager();
                    break;
                case 2:
                    employeeManager = new ContractEmployeeManager();
                    break;
                default:
                    employeeManager = null;
                    break;
            }

            return employeeManager;
        }
    }
}