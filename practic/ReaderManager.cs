using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
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

    public class ReaderManager
    {
        public List<Reader> Readers { get; private set; }

        private const string ReadersFileName = "readers.json";  
        public ReaderManager()
        {
            Readers = LoadReaders(); 
        }

        public void AddReader(string name, string email)
        {
            if (!IsValidName(name))
            {
                throw new Exception("Имя должно содержать только буквы и пробелы");
            }
            if (!IsValidEmail(email))
            {
                throw new Exception("Введите email правильно");
            }
            var reader = new Reader(name, email);
            Readers.Add(reader);
            SaveReaders();  
        }
        public bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z\s]+[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        public bool IsValidName(string name)
        {
            var regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ\s]+$");
            return regex.IsMatch(name);
        }

        public void RemoveReader(string email)
        {
            var reader = Readers.FirstOrDefault(r => r.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (reader == null)
            {
                throw new Exception("Читатель с таким email не найден.");
            }

            Readers.Remove(reader);
            SaveReaders(); 
        }

        public List<Reader> GetAllReaders()
        {
            return Readers;
        }

        private void SaveReaders()
        {
            var json = JsonConvert.SerializeObject(Readers, Formatting.Indented);
            File.WriteAllText(ReadersFileName, json);
        }

        private List<Reader> LoadReaders()
        {
            if (File.Exists(ReadersFileName))
            {
                var json = File.ReadAllText(ReadersFileName);
                return JsonConvert.DeserializeObject<List<Reader>>(json) ?? new List<Reader>();
            }

            return new List<Reader>();
        }
    }
}
