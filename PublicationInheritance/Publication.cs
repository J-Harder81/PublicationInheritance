using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationInheritance
{
    public enum PublicationType { Book, Journal, Magazine, Newspaper };

    public abstract class Publication
    {
        private bool _published = false;
        private DateTime _datePublished;
        private int _totalPages;

        public Publication(string title, string publisher, PublicationType type)
        {
            if (string.IsNullOrWhiteSpace(publisher))
                throw new ArgumentException("The publisher is required.");
            Publisher = publisher;

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("The title is required.");
            Title = title;

            Type = type;
        }

        public string Publisher { get; }

        public string Title { get; }

        public PublicationType Type { get; }

        public string? CopyrightName { get; private set; }

        public int CopyrightDate { get; private set; }

        public int Pages
        {
            get { return _totalPages; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The number of pages cannot be zero or negative.");
                _totalPages = value;
            }
        }

        public string GetPublicationDate()
        {
            if (!_published)
                return "NYP";
            else
                return _datePublished.ToString("d");
        }

        public void Publish(DateTime datePublished)
        {
            _published = true;
            _datePublished = datePublished;
        }

        public void Copyright(string copyrightName, int copyrightDate)
        {
            if (string.IsNullOrWhiteSpace(copyrightName))
                throw new ArgumentException("The name of the copyright holder is required.");
            CopyrightName = copyrightName;

            int currentYear = DateTime.Now.Year;
            if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
                throw new ArgumentOutOfRangeException($"The copyright year must be between {currentYear - 10} and {currentYear + 1}");
            CopyrightDate = copyrightDate;
        }

        public decimal Price { get; private set; }

        // A three-digit ISO currency symbol.
        public string? Currency { get; private set; }

        // Returns the old price, and sets a new price.
        public decimal SetPrice(decimal price, string currency)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "The price cannot be negative.");
            decimal oldValue = Price;
            Price = price;

            if (currency.Length != 3)
                throw new ArgumentException("The ISO currency symbol is a 3-character string.");
            Currency = currency;

            return oldValue;
        }

        public override string ToString() => Title;
    }
}
