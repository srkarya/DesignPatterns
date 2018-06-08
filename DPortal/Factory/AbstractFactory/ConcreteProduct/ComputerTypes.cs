using static DPortal.Factory.AbstractFactory.Enumerations;

namespace DPortal.Factory.AbstractFactory
{
    public class Desktop : ISystemType
    {
        public string GetSystemType()
        {
            return ComputerType.Desktop.ToString();
        }
    }

    public class Laptop : ISystemType
    {
        public string GetSystemType()
        {
            return ComputerType.Laptop.ToString();
        }
    }
}