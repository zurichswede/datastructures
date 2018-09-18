using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace googlepractice1
{
    public class FamilyMember : IComparable
    {
        public int Age { get; private set; }
        public string Name { get; private set; } 

        public FamilyMember(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString()
        {
            string result = "Name: " + this.Name + " Age: " + this.Age.ToString();
            return result;
        }


        public int CompareTo(object obj)
        {
            FamilyMember tmp = (FamilyMember)obj;
            return Age.CompareTo(tmp.Age);
        }
    }
}
