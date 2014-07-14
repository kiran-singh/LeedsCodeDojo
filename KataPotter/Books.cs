using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Books : List<Book>
    {
        public Books(IEnumerable<Book> distinct) : base(distinct)
        {
        }

        public double FinalPrice()
        {
            return this.Sum(y => y.Price)*(1 - (PriceCalculator.DiscountDictionary[this.Count()]));
        }

        public static IList<Books> DistinctBooks(Book[] books)
        {
            var booksList = new List<Book>(books);
            var distinctBooks = new List<Books>();

            while (booksList.Any())
            {
                var distinct = booksList.Distinct().ToList();

                distinct.ForEach(x => booksList.Remove(x));

                distinctBooks.Add(new Books(distinct));
            }
            return distinctBooks;
        }
    }
}