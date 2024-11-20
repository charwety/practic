using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace practic
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookManager = new BookManager();
            var readerManager = new ReaderManager();

            while (true)
            {
                Console.WriteLine("Выберете действие:");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Показать все книги");
                Console.WriteLine("4. Добавить читателя");
                Console.WriteLine("5. Удалить читателя");
                Console.WriteLine("6. Показать всех читателей");
                Console.WriteLine("7. Выход");
                Console.Write("Выберете действие: ");
                var option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            string title;
                            do
                            {
                                Console.Write("Введите название: ");
                                title = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(title))
                                {
                                    {
                                        Console.WriteLine("Сточка не может быть пустой");
                                    }
                                }
                            }
                            while (string.IsNullOrWhiteSpace(title));

                            string author;
                            do
                            {
                                Console.Write("Введите автора: ");
                                author = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(author))
                                {
                                    {
                                        Console.WriteLine("Сточка не может быть пустой");
                                    }
                                }
                            }
                            while (string.IsNullOrWhiteSpace(author));

                            Console.Write("Введите автора: ");
                            author = Console.ReadLine();
                            Console.Write("Введите год публикации: ");
                            int year = int.Parse(Console.ReadLine());
                            bookManager.AddBook(title, author, year);
                            Console.WriteLine("Книга успешно добавлена!");
                            break;

                        case "2":
                            Console.Write("Введите название книги для удаления: ");
                            var bookTitle = Console.ReadLine();
                            bookManager.RemoveBook(bookTitle);
                            Console.WriteLine("Книга успешно удалена!");
                            break;

                        case "3":
                            Console.WriteLine("Список всех книг:");
                            foreach (var book in bookManager.GetAllBooks())
                            {
                                Console.WriteLine(book);
                            }
                            break;

                        case "4":
                            Console.Write("Введите имя: ");
                            var name = Console.ReadLine();
                            while (!readerManager.IsValidName(name))
                            {
                                Console.WriteLine("Имя должно содержать только буквы и пробелы");
                                Console.WriteLine("Введите имя читателя");
                                name = Console.ReadLine();
                            }
                            Console.Write("Введите Email: ");
                            var email = Console.ReadLine();
                            while (!readerManager.IsValidEmail(email))
                            {
                                Console.WriteLine("Введите правильный email");
                                Console.WriteLine("Введите имя читателя");
                                email = Console.ReadLine();
                            }
                            readerManager.AddReader(name, email);
                            Console.WriteLine("Читатель успешно добавлен!");
                            break;

                        case "5":
                            Console.Write("Введите имя читателя для удаления: ");
                            var readerEmail = Console.ReadLine();
                            readerManager.RemoveReader(readerEmail);
                            Console.WriteLine("Читатель успешно удалён!");
                            break;

                        case "6":
                            Console.WriteLine("Список читателей:");
                            foreach (var reader in readerManager.GetAllReaders())
                            {
                                Console.WriteLine(reader);
                            }
                            break;

                        case "7":
                            return;

                        default:
                            Console.WriteLine("Не верный пункт меню. Попробуйте ещё раз");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
