using DPortal.Builder.IBuilder;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace DPortal.Builder.Director
{
    public class ConfigurationBuilder
    {
        public void BuildSystem(ISystemBuilder systemBuilder, NameValueCollection collection)
        {
            //systemBuilder.AddDrive(collection["Drive"]);
            //systemBuilder.AddMemory(collection["RAM"]);
            //systemBuilder.AddKeyboard(collection["Keyboard"]);
            //systemBuilder.AddMouse(collection["Mouse"]);
            //systemBuilder.AddTouchScreen(collection["TouchScreen"]);

            systemBuilder.AddDrive(collection["HDD"])
            .AddMemory(collection["RAM"])
            .AddKeyboard(collection["Keyboard"])
            .AddMouse(collection["Mouse"])
            .AddTouchScreen(collection["TouchScreen"]);
        }
    }
}