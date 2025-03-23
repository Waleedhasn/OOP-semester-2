using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment
{
    public class DegreeProgram
    {
        public string DegreeTitle { get; set; }
        public int Duration { get; set; } // Duration in years
        public List<Subject> Subjects { get; set; } = new List<Subject>();

        public bool AddSubject(Subject subject)
        {
            if (Subjects.Sum(s => s.CreditHours) + subject.CreditHours <= 20)
            {
                Subjects.Add(subject);
                return true;
            }
            return false;
        }
    }
}

