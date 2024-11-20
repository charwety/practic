using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class BookManager
    {
        public List<Book> Books { get; private set; }

        private const string BooksFileName = "books.json"; 

        public BookManager()
        {
            Books = LoadBooks();  
        }

        public void AddBook(string title, string author, int yearPublished)
        {
            var book = new Book(title, author, yearPublished);
            Books.Add(book);
            SaveBooks();  
        }

       
        public void RemoveBook(string title)
        {
            var book = Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book == null)
            {
                throw new Exception("Книга с таким названием не найдена.");
            }

            Books.Remove(book);
            SaveBooks();
        }


        public List<Book> GetAllBooks()
        {
            return Books;
        }


        private void SaveBooks()
        {
            var json = JsonConvert.SerializeObject(Books, Formatting.Indented);
            File.WriteAllText(BooksFileName, json);
        }


        private List<Book> LoadBooks()
        {
            if (File.Exists(BooksFileName))
            {
                var json = File.ReadAllText(BooksFileName);
                return JsonConvert.DeserializeObject<List<Book>>(json) ?? new List<Book>();
            }

            return new List<Book>();
        }
    }
}
