using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdapterDP.Adapter
{
    public class EmployeeAdapter : EmployeeManager, IEmployee
    {
        public override string GetAllEmployees()
        {
            string returnXml = base.GetAllEmployees();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(returnXml);
            return JsonConvert.SerializeObject(xmlDoc, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
