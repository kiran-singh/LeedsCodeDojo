using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

using NUnit.Framework;

namespace KataPotter.UnitTests
{
    [TestFixture]
    public class PriceCalculatorFixture
    {
        private PriceCalculator _priceCalculator;
        private Book _book1;
        private Book _book2;
        private Book _book3;
        private Book _book4;
        private Book _book5;

        [SetUp]
        public void SetUp()
        {
            _book1 = new Book { Id = 1, Price = 7.0 };
            _book2 = new Book { Id = 2, Price = 7.0 };
            _book3 = new Book { Id = 3, Price = 7.0 };
            _book4 = new Book { Id = 4, Price = 8.0 };
            _book5 = new Book { Id = 5, Price = 10.0 };

            _priceCalculator = new PriceCalculator();
        }

        [Test]
        public void Scan_OneBook_ReturnsSingleBookPrice()
        {
            // Arrange
            var expected = _book4.Price;

            // Act
            var actual = _priceCalculator.Scan(_book4);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_TwoSameBooks_ReturnsTotalBookPrice()
        {
            // Arrange
            var expected = _book2.Price * 2;

            // Act
            var actual = _priceCalculator.Scan(_book2, _book2);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_TwoDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
            };
            double totalPrice = list.Sum(x => x.Price);
            double expected = totalPrice - (totalPrice * 5 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_ThreeDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
                _book3,
            };
            double totalPrice = list.Sum(x => x.Price);
            double expected = totalPrice - (totalPrice * 10 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_FourDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
                _book3,
                _book4,
            };
            double totalPrice = list.Sum(x => x.Price);
            double expected = totalPrice - (totalPrice * 20 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_FiveDifferentBooks_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book2,
                _book3,
                _book4,
                _book5,
            };
            double totalPrice = list.Sum(x => x.Price);
            double expected = totalPrice - (totalPrice * 25 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_TwoSameBooksOneDifferent_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book1,
                _book4,
            };
            double totalPrice = list.Sum(x => x.Price);
            double expected = totalPrice - ((_book1.Price + _book4.Price) * 5 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_TwoSameBooksTwoDifferent_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book1,
                _book2,
                _book5
            };
            double totalPrice = list.Sum(x => x.Price);
            double expected = totalPrice - ((_book1.Price + _book2.Price + _book5.Price) * 10 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_ThreePairsSameBooksFiveDifferentTypes_ReturnsPriceWithCorrectDiscount()
        {
            // Arrange
            var list = new List<Book>
            {
                _book1,
                _book1,
                _book2,
                _book2,
                _book3,
                _book4,
                _book4,
                _book5,
            };
            double totalPrice = list.Sum(x => x.Price);
            double expected = totalPrice - ((_book1.Price + _book2.Price + _book3.Price + _book4.Price + _book5.Price) * 25 / 100) - ((_book1.Price + _book2.Price + _book4.Price) * 10 / 100);

            // Act
            var actual = _priceCalculator.Scan(list.ToArray());

            // Assert
            actual.Should().Be(expected);
        }
    }
}