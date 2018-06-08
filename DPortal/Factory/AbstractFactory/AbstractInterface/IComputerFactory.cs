namespace DPortal.Factory.AbstractFactory
{
    public interface IComputerFactory
    {
        IBrand Brand();
         
        IProcessor Processor();

        ISystemType SystemType();
    }
}
