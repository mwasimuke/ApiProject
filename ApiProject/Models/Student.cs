using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiProject.Models
{
    public class Student
    {
        public Student() {
            Chidren = new List<Child>();

        }
        public Student(string name, int age, string location, string country):base() {
            Name = name;
            Age = age;
            Location = location;
            Country = country;

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }

        public List<Child> Chidren { get; set; }
        
        }

    public class Child
    {
        public string Name { get;  set; }
    }
}
