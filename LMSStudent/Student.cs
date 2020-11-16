using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSStudent
{
    public class StudentLMS
    {
        public static StudentDetails studentDetails = new StudentDetails();
        public static List<StudentDetails> stdetaillist = new List<StudentDetails>();
        public static void Main(string[] args)
        {
            /*Console.WriteLine("Welcome to Student Database and teacher login page:");
            string teacherName = Console.ReadLine();
            if (teacherName == "SOTI" || teacherName == "soti")
            {
                bool condition = true;
                while (condition)
                {

                    Console.WriteLine(
                        "\nMenu\n" +
                        "1)Post/Put Method - Add Student\n" +
                        "2)Delete Method - Delete Student\n" +
                        "3)Get Method - Search Student\n" +
                        "4)Close\n\n");
                    Console.Write("Choose your option from above the Menu:");

                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("=======Student Added into DB=======");
                            AddStudent();
                            break;
                        case 2:
                            Console.WriteLine("========Student Removed from DB======");
                            RemoveStudent();
                            break;
                        case 3:
                            Console.WriteLine("=======Student Search from DB=======");
                            SearchStudent();
                            break;
                        case 4:
                            Console.WriteLine("Thank you");
                            condition = false;
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("\nThe Person is not having an access to Login Page\n");
            }
            Console.ReadLine();*/
        }

        public static void AddStudent()
        {
            StudentDetails studentDetails = new StudentDetails();
            Console.WriteLine("Student Id:{0}", studentDetails.studentID = stdetaillist.Count + 1);
            Console.Write("The Student Name:");
            studentDetails.studentName = Console.ReadLine();
            Console.Write("The Student Grade:");
            studentDetails.studentGrade = int.Parse(Console.ReadLine());
            Console.WriteLine("The Student Address:");
            studentDetails.schoolAddress = Console.ReadLine();
            stdetaillist.Add(studentDetails);
        }

        public static void RemoveStudent()
        {
            StudentDetails studentDetails = new StudentDetails();
            Console.WriteLine("Enter Student ID you want to delete:");
            var delete = int.Parse(Console.ReadLine());
            if (stdetaillist.Exists(a=> a.studentID == delete))
            {
                stdetaillist.RemoveAt(delete - 1);
                Console.WriteLine("Student id - {0} has been deleted from DB", delete);
            }
            else
            {
                    Console.WriteLine("Invalid Student ID");
            }
            stdetaillist.Add(StudentLMS.studentDetails);
        }

        public static void SearchStudent()
        {
            StudentDetails studentDetails = new StudentDetails();
            Console.Write("Search a Student by  its Student id :");
            int findByID = int.Parse(Console.ReadLine());
            Console.WriteLine(studentDetails.studentID);
            if (stdetaillist.Exists(x => x.studentID == findByID))
            {
                foreach (StudentDetails searchedBook in stdetaillist)
                {
                    if (searchedBook.studentID == findByID)
                    {
                        Console.WriteLine(
                            "Student ID :{0}\n" +
                            "Student Name :{1}\n" +
                            "Student Grade :{2}\n" +
                            "Student Address :{3}", searchedBook.studentID, searchedBook.studentName,
                            searchedBook.studentGrade, searchedBook.schoolAddress);
                    }
                }
            }
            else
            {
                Console.WriteLine("Student id {0} is not found from Website", findByID);
            }
        }

        public class StudentDetails
        {
            public int studentID;
            public string studentName;
            public int studentGrade;
            public string schoolAddress;
        }

    }
}
