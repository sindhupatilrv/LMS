using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is LMS - Books task
namespace LMSBooks
{
    public class ProgramBooks
    {
        public static List<Book> bookList = new List<Book>();
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        static Book book = new Book();
        static BorrowDetails borrow = new BorrowDetails();
        public static void AddBook()
        {
            Book book = new Book();
            Console.WriteLine("Book Id:{0}", book.bookId = bookList.Count + 1);
            Console.Write("The Name of the Book:");
            book.bookName = Console.ReadLine();
            Console.Write("The Price of the Book:");
            book.bookPrice = int.Parse(Console.ReadLine());
            Console.Write("Number of Books you want to Add into Library:");
            book.x = book.bookCount = int.Parse(Console.ReadLine());
            bookList.Add(book);
            foreach (var list in bookList)
            {
                Console.WriteLine("Total number of books in book list" + list.bookCount);
            }
        }

        public static void RemoveBook()
        {
            Book book = new Book();
            Console.Write("Enter Book id to be removed from Library : ");

            int Delete = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == Delete))
            {
                bookList.RemoveAt(Delete - 1); // Removeat= remove the element from List
                Console.WriteLine("Book id - {0} has been deleted from Library", Delete);
            }
            else
            {
                Console.WriteLine("Invalid Book ID");
            }
            bookList.Add(book);
        }

        public static void SearchBook()
        {
            Book book = new Book();
            Console.Write("Search a Book by  its Book id :");
            int findByID = int.Parse(Console.ReadLine());
            Console.WriteLine(book.bookId);
            if (bookList.Exists(x => x.bookId == findByID))
            {
                foreach (Book searchedBook in bookList)
                {
                    if (searchedBook.bookId == findByID)
                    {
                        Console.WriteLine(
                            "Book id :{0}\n" +
                            "Book name :{1}\n" +
                            "Book price :{2}\n" +
                            "Book Count :{3}", searchedBook.bookId, searchedBook.bookName, 
                                                searchedBook.bookPrice, searchedBook.bookCount);
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} is not found from Library", findByID);
            }
        }

        public static void Borrow()
        {
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            Console.WriteLine("User id : {0}", (borrow.userId = borrowList.Count + 1));
            Console.Write("Name :");
            borrow.userName = Console.ReadLine();
            Console.Write("Book id :");
            borrow.borrowBookId = int.Parse(Console.ReadLine());
            Console.Write("Number of Books : ");
            borrow.borrowCount = int.Parse(Console.ReadLine());
            Console.Write("Library Card num :");
            borrow.librarycardNO = Console.ReadLine();

            if (bookList.Exists(x => x.bookId == borrow.borrowBookId))
            {
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookCount >= searchId.bookCount - borrow.borrowCount 
                        && searchId.bookCount - borrow.borrowCount >= 0)
                    {
                        if (searchId.bookId == borrow.borrowBookId)
                        {
                            searchId.bookCount = searchId.bookCount - borrow.borrowCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Only {0} books are found", searchId.bookCount);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} is not found", borrow.borrowBookId);
            }

            borrowList.Add(borrow);
        }

        public static void ReturnBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter following details for returning a Book :");

            Console.Write("The Book id Number: ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books:");
            int returnCount = int.Parse(Console.ReadLine());

            if (bookList.Exists(y => y.bookId == returnId))
            {
                foreach (Book addReturnBookCount in bookList)
                {
                    if (addReturnBookCount.x >= returnCount + addReturnBookCount.bookCount)
                    {
                        if (addReturnBookCount.bookId == returnId)
                        {
                            addReturnBookCount.bookCount = addReturnBookCount.bookCount + returnCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Count exists the actual count");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", returnId);
            }
        }
    }

    public class Book
    {
        public int bookId;
        public string bookName;
        public int bookPrice;
        public int bookCount;
        public int x;
    }

    public class BorrowDetails
    {
        public int userId;
        public string userName;
        public string librarycardNO;
        public int borrowBookId;
        public DateTime borrowDate;
        public int borrowCount;
    }
}