using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DPortal
{
    public class ComputerSystem
    {
        //private string _RAM;
        //private string _HDDSize;

        public string RAM { get; set; }

        public string HDDSize { get; set; }

        public string Keyboard { get; set; }

        public string Mouse { get; set; }

        public string TouchScreen { get; set; }

        public ComputerSystem() { }


        //public ComputerSystem(string RAM, string HDD)
        //{
        //    _RAM = RAM;
        //    _HDDSize = HDD;
        //}

        //public string Build()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append(string.Format("RAM:{0} ", _RAM));
        //    sb.Append(string.Format("HDD:{0} ", _HDDSize));
        //    return sb.ToString();
        //}
    }
}