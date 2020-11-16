using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using LMSBooks;
using LMSStudent;


namespace LMSSChool
{
    public class Program
    {
        public static StudentLMS.StudentDetails studentDetails = new StudentLMS.StudentDetails();
        public static List<StudentLMS.StudentDetails> stdetaillist = new List<StudentLMS.StudentDetails>();
        public static List<Book> bookList = new List<Book>();
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        static Book book = new Book();
        static BorrowDetails borrow = new BorrowDetails();
        static Usermode usermode = new Usermode();
        public static List<Usermode> usermodelist = new List<Usermode>();
       //static List<>
        public class Usermode
        {
            public string admin;
            public string user;
        }
        public static void Main(string[] arg)
        {
            Console.WriteLine("Welcome to School Library and Enter your Name");
            
                string name = Console.ReadLine();

                if (name == "ADMIN" || name == "admin")
                {
                    Console.WriteLine("Welcome to " + name + " and you are having following access");
                    bool condition = true;
                    do
                        //  while (condition)
                    {
                        Console.WriteLine(
                            "\nMenu\n" +
                            "1)Student Section - Add Student\n" +
                            "2)Student Section - Delete Student\n" +
                            "3)Student Section - Search Student\n" +
                            "4)Library Section - Add book\n" +
                            "5)Library Section - Delete book\n" +
                            "6)Library Section - Search book\n" +
                            "7)Library Section - Borrow book\n" +
                            "8)Library Section - Return book\n" +
                            "9)Close the admin mode\n\n");
                        Console.Write("Choose your option from above the Menu:");

                        int option = int.Parse(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("=======Student Added into DB=======");
                                LMSStudent.StudentLMS.AddStudent();
                                break;
                            case 2:
                                Console.WriteLine("========Student Removed from DB======");
                                LMSStudent.StudentLMS.RemoveStudent();
                                break;
                            case 3:
                                Console.WriteLine("=======Student Search from DB=======");
                                LMSStudent.StudentLMS.SearchStudent();
                                break;
                            case 4:
                                Console.WriteLine("Admin added a Book to Library");
                                LMSBooks.ProgramBooks.AddBook();
                                break;
                            case 5:
                                Console.WriteLine("Admin Removed a Book to Library");
                                LMSBooks.ProgramBooks.RemoveBook();
                                break;
                            case 6:
                                Console.WriteLine("Admin is able to Search a Book form Library");
                                LMSBooks.ProgramBooks.SearchBook();
                                break;
                            case 7:
                                Console.WriteLine("Admin is able to borrow a Book to Library");
                                LMSBooks.ProgramBooks.Borrow();
                                break;
                            case 8:
                                Console.WriteLine("Admin return a Book to Library");
                                LMSBooks.ProgramBooks.ReturnBook();
                                break;
                            case 9:
                                Console.WriteLine("Thank you, Admin");
                                condition = false;
                                break;
                        }

                    } while (condition == true);
                }
                Console.WriteLine("Admin give right to give permissions to students");
                string name1 = Console.ReadLine();
                 if (name1 == "STUDENT" || name1 == "student")
                {
                    Console.WriteLine(
                        "Welcome to" + name + "and you are having following access only " +
                        "and for information please connect with School Administrator");
                    bool condition = true;
                    while (condition)
                    {
                        Console.WriteLine(
                            "\nMenu\n" +
                            "1)Add Book\n" +
                            "2)Delete book\n" +
                            "3)Search book\n" +
                            "4)Borrow book\n" +
                            "5)Return book\n" +
                            "6)Close\n\n");
                        Console.Write("Choose your option from above the Menu:");

                        int option = int.Parse(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Student is not having an access to add a book");
                                break;
                            case 2:
                                Console.WriteLine("Student is not having an access to add a book");
                                break;
                            case 3:
                                LMSBooks.ProgramBooks.SearchBook();
                                break;
                            case 4:
                                LMSBooks.ProgramBooks.Borrow();
                                break;
                            case 5:
                                LMSBooks.ProgramBooks.ReturnBook();
                                break;
                            case 6:
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

                Console.ReadLine();
            }
    }

}
