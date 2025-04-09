using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    public class Person
    {
        protected string name;
        protected string address;

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public string GetName() => name;
        public string GetAddress() => address;
        public void SetAddress(string newAddress) => address = newAddress;

        public override string ToString() => $"Person[name={name}, address={address}]";
    }
}
