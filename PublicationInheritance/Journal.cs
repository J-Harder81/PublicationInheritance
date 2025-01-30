using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationInheritance
{
    public sealed class Journal : Periodical
    {
        public Journal(string title, string fieldOfStudy, int volume, int issue, bool peerReviewed, string frequency, string publisher) :
               this(title, string.Empty, fieldOfStudy, volume, issue, peerReviewed, frequency, publisher)
        { }

        public Journal(string title, string issn, string fieldOfStudy, int volume, int issue, bool peerReviewed, string frequency, string publisher) : 
               base(title, issn, volume, issue, frequency, publisher, PublicationType.Journal)
        {
            if (string.IsNullOrEmpty(fieldOfStudy))
                throw new ArgumentException("The field of study is required.");

            FieldOfStudy = fieldOfStudy;

            PeerReviewed = peerReviewed;
        }

        public string FieldOfStudy { get; }

        public bool PeerReviewed { get; }

        public override bool Equals(object? obj)
        {
            if (obj is not Periodical journal)
                return false;
            else
                return ISSN == journal.ISSN;
        }

        public override int GetHashCode() => ISSN.GetHashCode();

        public override string ToString() => $"{Title}, {FieldOfStudy}, Volume {Volume}, Issue {Issue}, Peer-Reviewed: {PeerReviewed}, Frequency: {Frequency}";
    }
}
