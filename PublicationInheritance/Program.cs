using System;

namespace PublicationInheritance
{
    public class ClassExample
    {
        public static void Main()
        {
            var book = new Book("The Tempest", "0971655819", "Shakespeare, William",
                                "Public Domain Press");
            ShowPublicationInfo(book);
            book.Publish(new DateTime(2016, 8, 18));
            ShowPublicationInfo(book);

            var book2 = new Book("The Tempest", "Classic Works Press", "Shakespeare, William");
            Console.WriteLine($"{book.Title} and {book2.Title} are the same publication: " +
                              $"{((Publication)book).Equals(book2)}");

            // Testing Journal
            var journal = new Journal("Journal of AI Research", "Artificial Intelligence", 10, 1, true, "Monthly", "AI Press");
            ShowPublicationInfo(journal);
            journal.Publish(new DateTime(2023, 3, 1));
            ShowPublicationInfo(journal);

            // Testing Magazine
            var magazine = new Magazine("Tech Monthly", "Technology", "Tech Enthusiasts", 20, 5, "Monthly", "Tech Media");
            ShowPublicationInfo(magazine);
            magazine.Publish(new DateTime(2023, 5, 15));
            ShowPublicationInfo(magazine);

            // Testing Newspaper
            var newspaper = new Newspaper("Daily News", "National", "General News", 15, 120, "Daily", "News Corp");
            ShowPublicationInfo(newspaper);
            newspaper.Publish(new DateTime(2023, 1, 1));
            ShowPublicationInfo(newspaper);

            //Console.WriteLine($"{journal.Title} and {magazine.Title} are the same publication: " +
            // $"{((Publication)journal).Equals(magazine)}");
            Console.WriteLine($"{journal.Title} and {magazine.Title} are the same publication: " +
                  $"{((Publication)journal).Equals(magazine)}");
        }

        public static void ShowPublicationInfo(Publication pub)
        {
            string pubDate = pub.GetPublicationDate();
            Console.WriteLine($"{pub.Title}, " +
                              $"{(pubDate == "NYP" ? "Not Yet Published" : "published on " + pubDate):d} by {pub.Publisher}");
        }
    }
}

