﻿using static DPortal.Factory.AbstractFactory.Enumerations;

namespace DPortal.Factory.AbstractFactory
{
    public class I5 : IProcessor
    {
        public string GetProcessor()
        {
            return Processors.I5.ToString();
        }
    }

    public class I7 : IProcessor
    {
        public string GetProcessor()
        {
            return Processors.I7.ToString();
        }
    }
}