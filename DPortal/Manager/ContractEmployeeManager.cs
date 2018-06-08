namespace DPortal.Manager
{
    public class ContractEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 5;
        }

        public decimal GetHourlyPay()
        {
            return 12;
        }

        public decimal GetMedicalAllowance()
        {
            return 100;
        }
    }
}