using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DPortal.Builder.IBuilder;

namespace DPortal.Builder.ConcreteBuilder
{
    public class LaptopBuilder : ISystemBuilder
    {
        ComputerSystem laptop = new ComputerSystem();

        //public void AddDrive(string size)
        //{
        //    laptop.HDDSize = size;
        //}

        //public void AddKeyboard(string type)
        //{
        //    return;
        //}

        //public void AddMemory(string memory)
        //{
        //    laptop.RAM = memory;
        //}

        //public void AddMouse(string type)
        //{
        //    return;
        //}

        //public void AddTouchScreen(string enabled)
        //{
        //    laptop.TouchScreen = enabled;
        //}

        public ISystemBuilder AddDrive(string size)
        {
            laptop.HDDSize = size;
            return this;
        }

        public ISystemBuilder AddKeyboard(string type)
        {
            return this;
        }

        public ISystemBuilder AddMemory(string memory)
        {
            laptop.RAM = memory;
            return this;
        }

        public ISystemBuilder AddMouse(string type)
        {
            return this;
        }

        public ISystemBuilder AddTouchScreen(string enabled)
        {
            laptop.TouchScreen = enabled;
            return this;
        }

        public ComputerSystem GetSystem()
        {
            return laptop;
        }
    }
}