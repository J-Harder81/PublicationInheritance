using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationInheritance
{
    public sealed class Newspaper : Periodical
    {
        public Newspaper(string title, string region, string focus, int volume, int issue, string frequency, string publisher) :
               this(title, string.Empty, region, focus, volume, issue, frequency, publisher)
        { }

        public Newspaper(string title, string issn, string region, string focus, int volume, int issue, string frequency, string publisher) :
               base(title, issn, volume, issue, frequency, publisher, PublicationType.Newspaper)
        {
            if (string.IsNullOrEmpty(region))
                throw new ArgumentException("The region is required.");

            Region = region;

            if (string.IsNullOrEmpty(focus))
                throw new ArgumentException("The focus is required.");

            Focus = focus;
        }

        public string Region { get; }

        public string Focus { get; }

        public override bool Equals(object? obj)
        {
            if (obj is not Periodical newspaper)
                return false;
            else
                return ISSN == newspaper.ISSN;
        }

        public override int GetHashCode() => ISSN.GetHashCode();

        public override string ToString() => $"{Title}, {Region}, Focus: {Focus}, Volume {Volume}, Issue {Issue}, Frequency: {Frequency}";
    }
}
