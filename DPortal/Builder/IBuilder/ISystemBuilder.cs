﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPortal.Builder.IBuilder
{
    public interface ISystemBuilder
    {
        //void AddMemory(string memory);

        //void AddDrive(string size);

        //void AddKeyboard(string type);

        //void AddMouse(string type);

        //void AddTouchScreen(string enabled);

        ISystemBuilder AddMemory(string memory);

        ISystemBuilder AddDrive(string size);

        ISystemBuilder AddKeyboard(string type);

        ISystemBuilder AddMouse(string type);

        ISystemBuilder AddTouchScreen(string enabled);

        ComputerSystem GetSystem();
    }
}
