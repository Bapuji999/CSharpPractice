using System.Collections.Generic;

namespace Project1StudentManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Adding Static Students
                List<Student> StudentList = new List<Student>();

                Student student1 = new Student();
                student1.RollNo = 1;
                student1.Firstname = "Ajay";
                student1.MiddleName = "Kumar";
                student1.Lastname = "Mishra";
                student1.Age = 10;
                student1.ClassName = ClassList.Five;
                Subject s1 = new Subject();
                s1.SubjectName = "English";
                s1.MarkObtained = 80;
                Subject s2 = new Subject();
                s2.SubjectName = "Hindi";
                s2.MarkObtained = 70;
                student1.Subjects = new List<Subject>() {s1, s2};
                student1.Address = "Raipur";
                student1.Hobbies = new List<string>() { "Cricket", "Card" };
                student1.AddedDate = DateTime.Now;
                StudentList.Add(student1);

                Student student2 = new Student();
                student2.RollNo = 2;
                student2.Firstname = "Bijay";
                student2.MiddleName = "Kumar";
                student2.Lastname = "Mishra";
                student2.Age = 16;
                student2.ClassName = ClassList.Five;
                Subject s3 = new Subject();
                s3.SubjectName = "English";
                s3.MarkObtained = 75;
                Subject s4 = new Subject();
                s4.SubjectName = "Hindi";
                s4.MarkObtained = 60;
                student2.Subjects = new List<Subject>() { s3, s4 };
                student2.Address = "Sambalpur";
                student2.Hobbies = new List<string>() { "Kabadi" };
                student2.AddedDate = DateTime.Now;
                StudentList.Add(student2);

                start(StudentList);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void start(List<Student> StudentList)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nWelcome to Student Menu.....\nPlease select any option....");
                Console.WriteLine("1. Add Student to system.\n" +
                                  "2. Get all the students with all the details.\n" +
                                  "3. Filter students by different fields.\n" +
                                  "4. Find the student(s) whose age is in between 15 to 25.\n" +
                                  "5. Find the details of the student who is topper of the class.\n" +
                                  "6. Find the roll no of students who is in the Nth position of topper list, where N can be any integer greater than 1.\n" +
                                  "7. Find all the classes where the student belongs to  every 10 seconds.\n");
                Console.ForegroundColor = ConsoleColor.Red;
                int option = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow;

                switch (option)
                {
                    case 1:
                        AddStudent(StudentList);
                        break;
                    case 2:
                        DisplayAllStudent(StudentList);
                        break;
                    case 3:
                        FilterSudents(StudentList);
                        break;
                    case 4:
                        FindYoung(StudentList);
                        break;
                    case 5:
                        FindTopper(StudentList);
                        break;
                    case 6:
                        FindRank(StudentList);
                        break;
                    case 7:
                        StudentList.DisplayClass();
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Option.");
                        break;
                }
                start(StudentList);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void DisplayAllStudent(List<Student> StudentList)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student List:\n");
                foreach (var student in StudentList)
                {
                    Console.WriteLine($"Roll: {student.RollNo}");
                    Console.WriteLine($"First Name: {student.Firstname}");
                    Console.WriteLine($"Middle Name: {student.MiddleName}");
                    Console.WriteLine($"Last Name: {student.Lastname}");
                    Console.WriteLine($"Age: {student.Age}");
                    Console.WriteLine($"Class: {student.ClassName}");
                    Console.WriteLine("Subjects:");
                    foreach (var subject in student.Subjects)
                    {
                        Console.WriteLine($"Name: {subject.SubjectName}, Mark Obtained: {subject.MarkObtained}");
                    }
                    Console.WriteLine($"Address: {student.Address}");
                    Console.WriteLine("Hobbies: " + string.Join(", ", student.Hobbies));
                    Console.WriteLine("Added Date: " + student.AddedDate + "\n");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void AddStudent(List<Student> StudentList)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Student student = new Student();
                Console.WriteLine("Enter RollNo:");
                student.RollNo = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter First Name:");
                student.Firstname = Console.ReadLine();
                Console.WriteLine("Enter Middle Name:");
                student.MiddleName = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                student.Lastname = Console.ReadLine();
                Console.WriteLine("Enter Age:");
                student.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Class Name(In Number):");
                int classInput = int.Parse(Console.ReadLine());
                student.ClassName = (ClassList)classInput;
                AddSubject(student);
                Console.WriteLine("Enter Address:");
                student.Address = Console.ReadLine();
                AddHobbis(student);
                student.AddedDate = DateTime.Now;
                StudentList.Add(student);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void AddSubject(Student student)
        {
            try
            {
                Console.WriteLine("Plese select\n 1. Add Subject.\n 2. Added all Subjects.");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Subject s = new Subject();
                    Console.WriteLine("Enter Subject Name:");
                    s.SubjectName = Console.ReadLine();
                    Console.WriteLine("Enter Mark Obtained:");
                    s.MarkObtained = int.Parse(Console.ReadLine());
                    student.Subjects?.Add(s);
                    AddSubject(student);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void AddHobbis(Student student)
        {
            try
            {
                if (student.Hobbies?.Count == null || student.Hobbies?.Count == 0)
                {
                    Console.WriteLine("Enter Hobby Name:");
                    var hobby = Console.ReadLine();
                    student.Hobbies?.Add(hobby);
                    AddHobbis(student);
                }
                else if (student.Hobbies?.Count < 7)
                {
                    Console.WriteLine("Plese select\n 1. Add Hobby.\n 2.Added all Hobbis.");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        Console.WriteLine("Enter Hobby Name:");
                        student.Hobbies?.Add(Console.ReadLine());
                        AddHobbis(student);
                    }
                    else { return; }
                }
                else
                {
                    Console.WriteLine("A student can have at most 7 hobbies and you have reached the maximum limit.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterSudents(List<Student> StudentList)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Please choose the filter option.\n" +
                                  "1. First Name\n" +
                                  "2. Middle Name\n" +
                                  "3. Last Name\n" +
                                  "4. Class\n" +
                                  "5. Subjects\n" +
                                  "6. Address\n" +
                                  "7. Hobbies\n" +
                                  "8. Added Date Time");
                int option = int.Parse(Console.ReadLine());
                FilterName fl;
                switch (option)
                {
                    case 1:
                        fl = new FilterName(FilterByFirstName);
                        fl(StudentList);
                        break;
                    case 2:
                        fl = new FilterName(FilterByMiddleName);
                        fl(StudentList);
                        break;
                    case 3:
                        fl = new FilterName(FilterByLastName);
                        fl(StudentList);
                        break;
                    case 4:
                        fl = new FilterName(FilterByClass);
                        fl(StudentList);
                        break;
                    case 5:
                        fl = new FilterName(FilterBySubject);
                        fl(StudentList);
                        break;
                    case 6:
                        fl = new FilterName(FilterByAddress);
                        fl(StudentList);
                        break;
                    case 7:
                        fl = new FilterName(FilterByHobbies);
                        fl(StudentList);
                        break;
                    case 8:
                        fl = new FilterName(FilterByDateTime);
                        fl(StudentList);
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Option.");
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);}
        }
        public static void FilterByFirstName(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter First Name:");
                string fistName = Console.ReadLine();
                var list = StudentList.FindAll((student) => student.Firstname == fistName);
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterByMiddleName(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter Middle Name:");
                string middleName = Console.ReadLine();
                var list = StudentList.FindAll((student) => student.MiddleName == middleName);
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterByLastName(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter Last Name:");
                string lastName = Console.ReadLine();
                var list = StudentList.FindAll((student) => student.Lastname == lastName);
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterByClass(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter Class Name(In Number):");
                int classInput = int.Parse(Console.ReadLine());
                var list = StudentList.FindAll((student) => student.ClassName == (ClassList)classInput);
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterBySubject(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter Subject:");
                string subject = Console.ReadLine();
                List<Student> list = new List<Student>();
                foreach (var student in StudentList)
                {
                    var subjectClass = student.Subjects.Find(x => x.SubjectName == subject);
                    if (subjectClass != null)
                    {
                        list.Add(student);
                    }
                }
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterByAddress(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter Address:");
                string address = Console.ReadLine();
                var list = StudentList.FindAll((student) => student.Address == address);
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterByHobbies(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter Hobby:");
                string address = Console.ReadLine();
                List<Student> list = new List<Student>();
                foreach (var student in StudentList)
                {
                    var hobby = student.Hobbies.Find(x => x == address);
                    if (hobby != null)
                    {
                        list.Add(student);
                    }
                }
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FilterByDateTime(List<Student> StudentList)
        {
            try
            {
                Console.WriteLine("Enter DateTime:");
                DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                var list = StudentList.FindAll(x => x.AddedDate.CompareTo(dateTime) == 0);
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FindYoung(List<Student> StudentList)
        {
            try
            {
                var list = StudentList.FindAll(x => x.Age >= 15 && x.Age <= 25);
                if (list.Count > 0)
                {
                    DisplayAllStudent(list);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("No match found.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FindTopper(List<Student> StudentList)
        {
            try
            {
                Student topper = StudentList[0];
                int intialHigh = 0;
                foreach (var mark in topper.Subjects)
                {
                    intialHigh += mark.MarkObtained;
                }
                foreach (var student in StudentList)
                {
                    int totalmark = 0;
                    foreach(var mark in student.Subjects)
                    {
                        totalmark += mark.MarkObtained;
                    }
                    if (totalmark > intialHigh)
                    {
                        topper = student;
                    }
                }
                List<Student> list = new List<Student>() {topper};
                DisplayAllStudent(list);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        public static void FindRank(List<Student> StudentList)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Please Enter The RollNo.");
                int rollNo = int.Parse(Console.ReadLine());
                List<StudentWithTotalMark> rankList = new List<StudentWithTotalMark>();
                foreach (var student in StudentList)
                {
                    StudentWithTotalMark studentWithTotalMark = new StudentWithTotalMark();
                    studentWithTotalMark.RollNo = student.RollNo;
                    int totalmark = 0;
                    foreach (var mark in student.Subjects)
                    {
                        totalmark += mark.MarkObtained;
                    }
                    studentWithTotalMark.TotalMark = totalmark;
                    rankList.Add(studentWithTotalMark);
                }
                MarkCompare totalMarksComparer = new MarkCompare();
                rankList.Sort(totalMarksComparer);
                int index = rankList.FindIndex(x => x.RollNo == rollNo);
                if (index == 0)
                {
                    Console.WriteLine($"The student with Rollno {rollNo} is the topper or the class.");
                }
                else if( index > 0)
                {
                    Console.WriteLine($"Result: {index + 1}");
                }
                else
                {
                    Console.WriteLine($"No student with given roll no.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        
        delegate void FilterName(List<Student> StudentList);
    }
}