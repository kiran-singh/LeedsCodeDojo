using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class PriceCalculator
    {
        private static readonly IDictionary<int, double> DiscountDictionary = new Dictionary<int, double>
        {
            {1, 0},
            {2, 0.05},
            {3, 0.10},
            {4, 0.20},
            {5, 0.25},
        };

        public double Scan(params Book[] books)
        {
            var booksList = new List<Book>(books);
            var lists = new List<IList<Book>>();

            while (booksList.Any())
            {
                var distinct = booksList.Distinct().ToList();

                distinct.ForEach(x => booksList.Remove(x));

                lists.Add(distinct);
            }

            var totalPrice = lists.Sum(x => x.Sum(y => y.Price)*(1 - (DiscountDictionary[x.Count()])));
            return Math.Round(totalPrice, 2); 
        }
    }
}