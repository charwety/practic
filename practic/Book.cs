using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic
{
    public class Book
    {
        public string Id { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }

        public Book(string title, string author, int yearPublished, string id = null)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Не правильный формат");
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Не правильный формат");
            if (yearPublished > DateTime.Now.Year) throw new ArgumentException("Не правильный формат");

            Id = id ?? Guid.NewGuid().ToString(); 
            Title = title;
            Author = author;
            YearPublished = yearPublished;
        }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, Год: {YearPublished}";
        }
    }
}
