using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationInheritance
{
    public sealed class Magazine : Periodical
    {
        public Magazine(string title, string category, string audience, int volume, int issue, string frequency, string publisher) :
               this(title, string.Empty, category, audience, volume, issue, frequency, publisher)
        { }

        public Magazine(string title, string issn, string category, string audience, int volume, int issue, string frequency, string publisher) : 
               base(title, issn, volume, issue, frequency, publisher, PublicationType.Magazine)
        {
            if (string.IsNullOrEmpty(category))
                throw new ArgumentException("The category is required.");

            Category = category;

            if (string.IsNullOrEmpty(audience))
                throw new ArgumentException("The target audience is required.");

            Audience = audience;
        }

        public string Category { get; }

        public string Audience { get; }

        public override bool Equals(object? obj)
        {
            if (obj is not Periodical magazine)
                return false;
            else
                return ISSN == magazine.ISSN;
        }

        public override int GetHashCode() => ISSN.GetHashCode();

        public override string ToString() => $"{Title}, {Category}, Target Audience: {Audience}, Volume {Volume}, Issue {Issue}, Frequency: {Frequency}";
    }
}
