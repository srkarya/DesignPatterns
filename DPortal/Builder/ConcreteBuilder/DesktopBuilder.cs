using DPortal.Builder.IBuilder;

namespace DPortal.Builder.ConcreteBuilder
{
    public class DesktopBuilder : ISystemBuilder
    {
        ComputerSystem desktop = new ComputerSystem();

        //public void AddDrive(string size)
        //{
        //    desktop.HDDSize = size;
        //}

        //public void AddKeyboard(string type)
        //{
        //    desktop.Keyboard = type;
        //}

        //public void AddMemory(string memory)
        //{
        //    desktop.RAM = memory;
        //}

        //public void AddMouse(string type)
        //{
        //    desktop.Mouse = type;
        //}

        //public void AddTouchScreen(string enabled)
        //{
        //    return;
        //}


        public ISystemBuilder AddDrive(string size)
        {
            desktop.HDDSize = size;
            return this;
        }

        public ISystemBuilder AddKeyboard(string type)
        {
            desktop.Keyboard = type;
            return this;
        }

        public ISystemBuilder AddMemory(string memory)
        {
            desktop.RAM = memory;
            return this;
        }

        public ISystemBuilder AddMouse(string type)
        {
            desktop.Mouse = type;
            return this;
        }

        public ISystemBuilder AddTouchScreen(string enabled)
        {
            return this;
        }

        public ComputerSystem GetSystem()
        {
            return desktop;
        }
    }
}