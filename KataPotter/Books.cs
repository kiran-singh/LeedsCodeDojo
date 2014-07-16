using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class Books : List<Book>
    {
        public Books(IEnumerable<Book> distinct) : base(distinct)
        {
        }

        public double FinalPrice(IDictionary<int, double> discountDictionary)
        {
            return this.Sum(y => y.Price)*(1 - (discountDictionary[this.Count()]));
        }
    }
}