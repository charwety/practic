using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic
{
    public class ReaderManager
    {
        public List<Reader> Readers { get; set; }
        public ReaderManager()
        {
            Readers = new List<Reader>();
        }
        public void AddReader(Reader reader)
        {
            if (Readers.Any(r => r.Id == reader.Id))
            {
                throw new InvalidOperationException("Читатель с таким Id уже существует");
            }
            Readers.Add(reader);
        }
        public void RemoveReader (string readerId)
        {
            var reader = GetReader(readerId);
            if (reader==null)
            {
                throw new KeyNotFoundException("Читатель с таким Id не найден");
            }
            Readers.Remove(reader);
        }
        public Reader GetReader(string readerId)
        {
            return Readers.FirstOrDefault(r => r.Id == readerId);
        }
        public List<Reader> GetAllReaders()
        {
            return Readers;
        }
    }
}
