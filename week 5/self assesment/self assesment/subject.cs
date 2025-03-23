using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment
{
    public class Subject
    {
        public int SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int CreditHours { get; set; }
        public int Semester { get; set; }

        public void GetSubjectDetails()
        {
            Console.WriteLine($"Subject Code: {SubjectCode}, Subject Name: {SubjectName}, Credit Hours: {CreditHours}");
        }

        public int GetCreditHours()
        {
            return CreditHours;
        }

        public int GetSemester()
        {
            return Semester;
        }
    }
}


