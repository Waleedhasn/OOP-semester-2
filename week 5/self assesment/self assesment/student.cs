using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment
{
    public class Student
    {
        public string Name { get; set; }
        public int StudentID { get; set; }
        public int Age { get; set; }
        public int MatricMarks { get; set; }
        public int InterMarks { get; set; }
        public int EcatMarks { get; set; }
        public string DegreeProgram { get; set; }
        public List<string> Preferences { get; set; } = new List<string>();
        public List<Registration> Registrations { get; set; } = new List<Registration>();

        public float GetAggregate()
        {
            float aggregate = (MatricMarks * 0.1f) + (InterMarks * 0.3f) + (EcatMarks * 0.6f);
            return aggregate;
        }

        public void GetDetails()
        {
            Console.WriteLine($"Name: {Name}, Student ID: {StudentID}, Age: {Age}, Aggregate: {GetAggregate()}");
        }
    }
}


