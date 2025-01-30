using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationInheritance
{
    public abstract class Periodical : Publication
    {
        public Periodical(string title, int volume, int issue, string frequency, string publisher, PublicationType periodicalType) :
               this(title, string.Empty, volume, issue, frequency, publisher, periodicalType)
        { }

        public Periodical(string title, string issn, int volume, int issue, string frequency, string publisher, PublicationType periodicalType) : 
               base(title, publisher, periodicalType)
        {
            if (!string.IsNullOrEmpty(issn))
            {
                // Determine if ISSN length is correct.
                if (!(issn.Length == 8))
                    throw new ArgumentException("The ISSN must be an 8-character numeric string.");
                if (!ulong.TryParse(issn, out _))
                    throw new ArgumentException("The ISSN can consist of numeric characters only.");
            }
            
            ISSN = issn;

            if (volume <= 0)
                throw new ArgumentException("The volume number cannot be zero or negative.");
            
            Volume = volume;

            if (issue <= 0)
                throw new ArgumentException("The issue number cannot be zero or negative.");

            Issue = issue;

            if (string.IsNullOrEmpty(frequency))
                throw new ArgumentException("The frequency is required.");

            Frequency = frequency;

            PeriodicalType = periodicalType;
        }

        public string ISSN { get; }

        public int Volume { get; }
        
        public int Issue { get; }

        public string Frequency { get; }

        public PublicationType PeriodicalType { get; }
               
        public override string ToString() => $"{Title}, Volume {Volume}, Issue {Issue}, Frequency: {Frequency}";
    }
}
