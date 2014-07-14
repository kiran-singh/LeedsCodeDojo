using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class PriceCalculator
    {
        public static readonly IDictionary<int, double> DiscountDictionary = new Dictionary<int, double>
        {
            {1, 0},
            {2, 0.05},
            {3, 0.10},
            {4, 0.20},
            {5, 0.25},
        };

        public double Scan(params Book[] books)
        {
            var distinctBooks = Books.DistinctBooks(books);

            return Math.Round(distinctBooks.Sum(x => x.FinalPrice()), 2); 
        }
    }
}