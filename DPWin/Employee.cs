using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPWin
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Address EmpAddress { get; set; }

        public Employee ShallowCopy() {
            return (Employee)this.MemberwiseClone();
        }

        public Employee DeepCopy() {
            Employee other = (Employee)this.MemberwiseClone();
            other.EmpAddress = new Address(this.EmpAddress.DoorNumber,
                this.EmpAddress.StreetNumber, this.EmpAddress.Zipcode,
                this.EmpAddress.Country);
            return other;
        }

        public override string ToString()
        {
            return string.Format("Emp ID :{0}, Emp Name : {1}, {2}",
            this.Id, this.Name, this.EmpAddress.ToString());
        }
    }

    public class Address
    {
        public Address() { }
        public Address(int doorNumber, int streetNumber,
            int zipCode, string country)
        {
            this.Country = country;
            this.DoorNumber = doorNumber;
            this.StreetNumber = streetNumber;
            this.Zipcode = zipCode;
        }

        public int DoorNumber { get; set; }
        public int StreetNumber { get; set; }
        public int Zipcode { get; set; }
        public string Country { get; set; }
        public override string ToString()
        {
            return string.Format(Environment.NewLine + "Emp Address: {0}",
                string.Format("{0}, {1}, {2}, {3}",
                this.DoorNumber, this.StreetNumber,
                this.Zipcode.ToString(), this.Country));
        }
    }
}
