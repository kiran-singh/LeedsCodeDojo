using System;
using System.Collections.Generic;

namespace KataPotter
{
    public class PriceCalculator
    {
        private static readonly IDictionary<int, double> DiscountDictionary
            = new Dictionary<int, double>
            {
                {1, 0},
                {2, 0.05},
                {3, 0.10},
                {4, 0.20},
                {5, 0.25},
            };

        public double Scan(params Book[] books)
        {
            var finalPrice = new DistinctBooks(books).FinalPrice(DiscountDictionary);

            return Math.Round(finalPrice, 2);
        }
    }
}