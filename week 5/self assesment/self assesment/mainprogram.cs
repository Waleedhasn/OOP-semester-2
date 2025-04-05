using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assesment
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Subject> subjects = new List<Subject>();
        static List<DegreeProgram> degreePrograms = new List<DegreeProgram>();

        static void Main(string[] args)
        {
            // Pre-populate with sample subjects and programs
            subjects.Add(new Subject { SubjectCode = 101, SubjectName = "Mathematics", CreditHours = 3, Semester = 1 });
            subjects.Add(new Subject { SubjectCode = 102, SubjectName = "Physics", CreditHours = 3, Semester = 1 });

            degreePrograms.Add(new DegreeProgram { DegreeTitle = "BSCS", Duration = 4 });
            degreePrograms.Add(new DegreeProgram { DegreeTitle = "BSIT", Duration = 4 });
            degreePrograms.Add(new DegreeProgram { DegreeTitle = "BBA", Duration = 4 });
            degreePrograms.Add(new DegreeProgram { DegreeTitle = "MBA", Duration = 2 });

            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("********************************************");
                Console.WriteLine("                      UAMS                  ");
                Console.WriteLine("********************************************");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Degree Program");
                Console.WriteLine("3. Generate Merit");
                Console.WriteLine("4. View Registered Students");
                Console.WriteLine("5. View Students of a Specific Program");
                Console.WriteLine("6. Register Subjects for a Specific Student");
                Console.WriteLine("7. Calculate Fees for all Registered Students");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Enter Option:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddDegreeProgram();
                        break;
                    case 3:
                        GenerateMerit();
                        break;
                    case 4:
                        ViewRegisteredStudents();
                        break;
                    case 5:
                        ViewSpecificDegree();
                        break;
                    case 6:
                        RegisterSubjects();
                        break;
                    case 7:
                        GenerateFee();
                        break;
                    case 8:
                        return;
                }
            }
        }

        static void AddDegreeProgram()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Enter Degree Program Title:         *");
            string degreeTitle = Console.ReadLine();
            Console.WriteLine("* Enter Duration (years):             *");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("***************************************");

            degreePrograms.Add(new DegreeProgram { DegreeTitle = degreeTitle, Duration = duration });
            Console.WriteLine("Degree program added successfully!");
        }

        static void AddStudent()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Enter Student Name:                 *");
            string name = Console.ReadLine();
            Console.WriteLine("* Enter Student ID:                   *");
            int studentID = int.Parse(Console.ReadLine());
            Console.WriteLine("* Enter Age:                          *");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("* Enter FSC Marks:                    *");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("* Enter Ecat Marks:                   *");
            int ecatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("* Available Degree Programs:          *");
            degreePrograms.ForEach(p => Console.WriteLine(p.DegreeTitle));
            Console.WriteLine("* Enter how many preferences to enter:*");
            int numPreferences = int.Parse(Console.ReadLine());
            List<string> preferences = new List<string>();

            for (int i = 0; i < numPreferences; i++)
            {
                Console.WriteLine($"* Enter Preference {i + 1}:               *");
                string preference = Console.ReadLine();
                preferences.Add(preference);
            }
            Console.WriteLine("***************************************");

            Student student = new Student
            {
                Name = name,
                StudentID = studentID,
                Age = age,
                MatricMarks = fscMarks,
                InterMarks = ecatMarks,
                Preferences = preferences
            };

            students.Add(student);
            Console.WriteLine("Student added successfully!");
        }

        static void GenerateMerit()
        {
            // Assuming a predefined seat count for demonstration
            int availableSeats = 10;

            var sortedStudents = students.OrderByDescending(s => s.GetAggregate()).Take(availableSeats).ToList();

            Console.WriteLine("***************************************");
            Console.WriteLine("* Merit List:                         *");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"* Student Name: {student.Name}       *");
                Console.WriteLine($"* Student ID: {student.StudentID}    *");
                Console.WriteLine($"* Degree Program: {student.DegreeProgram} *");
                Console.WriteLine($"* Aggregate: {student.GetAggregate()}    *");
            }
            Console.WriteLine("***************************************");
        }

        static void ViewRegisteredStudents()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Registered Students:                *");
            foreach (var student in students)
            {
                Console.WriteLine($"* Student Name: {student.Name}       *");
                Console.WriteLine($"* Student ID: {student.StudentID}    *");
                Console.WriteLine($"* Degree Program: {student.DegreeProgram} *");
            }
            Console.WriteLine("***************************************");
        }

        static void ViewSpecificDegree()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Enter Degree Program:               *");
            string degreeProgram = Console.ReadLine();
            Console.WriteLine("***************************************");

            foreach (var student in students)
            {
                if (student.DegreeProgram == degreeProgram)
                {
                    Console.WriteLine($"* Student Name: {student.Name}       *");
                    Console.WriteLine($"* Student ID: {student.StudentID}    *");
                    Console.WriteLine($"* Degree Program: {student.DegreeProgram} *");
                }
            }
            Console.WriteLine("***************************************");
        }

        static void RegisterSubjects()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Enter Student Name:                 *");
            string studentName = Console.ReadLine();
            Console.WriteLine("* Enter Subject Code:                 *");
            int subjectCode = int.Parse(Console.ReadLine());

            Console.WriteLine("***************************************");

            Student student = students.FirstOrDefault(s => s.Name == studentName);
            Subject subject = subjects.FirstOrDefault(s => s.SubjectCode == subjectCode);

            if (student != null && subject != null)
            {
                var totalCreditHours = student.Registrations.Sum(r => subjects.First(s => s.SubjectCode == r.SubjectCode).CreditHours);

                if (totalCreditHours + subject.CreditHours <= 9)
                {
                    Registration registration = new Registration
                    {
                        StudentID = student.StudentID,
                        SubjectCode = subjectCode,
                        Semester = 1 // Assuming semester 1 for simplicity
                    };

                    student.Registrations.Add(registration);
                    registration.RegisterSubject();
                }
                else
                {
                    Console.WriteLine("Cannot register, exceeds 9 credit hours.");
                }
            }
            else
            {
                Console.WriteLine("Student or subject not found.");
            }
        }

        static void GenerateFee()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("* Fee Details:                        *");
            foreach (var student in students)
            {
                double totalFee = student.Registrations.Sum(r => subjects.First(s => s.SubjectCode == r.SubjectCode).CreditHours * 1000); // Assuming fee per credit hour is 1000
                Console.WriteLine($"* Student Name: {student.Name}       *");
                Console.WriteLine($"* Student ID: {student.StudentID}    *");
                Console.WriteLine($"* Total Fee: {totalFee}              *");
            }
            Console.WriteLine("***************************************");
        }
    }
}
