﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AdapterDP
{
    [Serializable]
    public class Employee
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        Employee() { }

        public Employee(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }

    public class EmployeeManager
    {
        public List<Employee> employees;

        public EmployeeManager()
        {

            employees = new List<Employee>();
            this.employees.Add(new Employee(1, "John"));
            this.employees.Add(new Employee(2, "Michael"));
            this.employees.Add(new Employee(3, "Jason"));
        }


        // XML Format
        public virtual string GetAllEmployees()
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(employees.GetType());
            var settings = new XmlWriterSettings(); settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, employees, emptyNamepsaces);
                return stream.ToString();
            }
        }
    }
}
