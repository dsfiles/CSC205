namespace Week02
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
            Console.Write($"{book.Title} and {book2.Title} are the same publication: " +
                  $"{((Publication)book).Equals(book2)}");

            // newly added testing
            var np = new Newspaper("The Seattle Times", "The Seattle Times Company", PublicationType.Newspaper, "20250204");
            np.Publish(DateTime.Now);
            Console.WriteLine($"current issue {(np.IssueNumber)} \n~~~ The Seattle Times ~~~");
            ShowPublicationInfo(np);

            var jn = new Newspaper("Journal of the ACM", "Association for Computing Machinery", PublicationType.Journal, "Feb2025");
            jn.Publish(new DateTime(2025, 2, 1));
            Console.WriteLine($"current issue {(np.IssueNumber)} \n~~~ Journal of the ACMs ~~~");
            ShowPublicationInfo(jn);
        }

        public static void ShowPublicationInfo(Publication pub)
        {
            string pubDate = pub.GetPublicationDate();
            Console.WriteLine($"{pub.Title}, " +
                      $"{(pubDate == "NYP" ? "Not Yet Published" : "published on " + pubDate):d} by {pub.Publisher}");
        }
    }
}
