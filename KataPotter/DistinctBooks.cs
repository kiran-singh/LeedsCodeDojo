using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class DistinctBooks
    {
        private readonly List<Books> _distinctBooks;

        public DistinctBooks(IEnumerable<Book> books)
        {
            var booksList = new List<Book>(books);
            _distinctBooks = new List<Books>();

            while (booksList.Any())
            {
                var distinct = booksList.Distinct().ToList();

                distinct.ForEach(x => booksList.Remove(x));

                _distinctBooks.Add(new Books(distinct));
            }
        }

        public double FinalPrice(IDictionary<int, double> discountDictionary)
        {
            return _distinctBooks.Sum(x => x.FinalPrice(discountDictionary));
        }
    }
}