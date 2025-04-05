using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment
{
    public class Registration
    {
        public int StudentID { get; set; }
        public int SubjectCode { get; set; }
        public int Semester { get; set; }
        public int Marks { get; set; }
        public string Status { get; set; }

        public void RegisterSubject()
        {
            Console.WriteLine("Subject registered successfully!");
        }

        public int GetMarks()
        {
            return Marks;
        }

        public string GetStatus()
        {
            return Status;
        }
    }
}

