using System;

namespace ConsoleApp12Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new PoemManager();

            var poem1 = new Poem { Title = "Sonnet 18", Author = "William Shakespeare", YearOfWriting = 1609, Text = "Shall I compare thee to a summer's day...", Theme = "Love" };
            var poem2 = new Poem { Title = "The Road Not Taken", Author = "Robert Frost", YearOfWriting = 1916, Text = "Two roads diverged in a yellow wood...", Theme = "Life Choices" };
            var poem3 = new Poem { Title = "The Raven", Author = "Edgar Allan Poe", YearOfWriting = 1845, Text = "Once upon a midnight dreary...", Theme = "Loss and Mourning" };

            manager.AddPoem(poem1);
            manager.AddPoem(poem2);
            manager.AddPoem(poem3);

            manager.DeletePoem(poem2);

            var updatedPoem = new Poem { Title = "Sonnet 18", Author = "William Shakespeare", YearOfWriting = 1609, Text = "Shall I compare thee to a summer's day? Thou art more lovely...", Theme = "Love" };
            manager.UpdatePoem(poem1, updatedPoem);

            var results = manager.Search(p => p.Author == "William Shakespeare" && p.YearOfWriting == 1609 && p.Theme == "Love");
            foreach (var poem in results)
            {
                Console.WriteLine($"Title: {poem.Title}, Author: {poem.Author}, Year: {poem.YearOfWriting}, Theme: {poem.Theme}");
                Console.WriteLine($"Text: {poem.Text}\n");
            }

            var titleReport = manager.ReportByTitle();
            Console.WriteLine("\n=== Report by Title ===");
            manager.DisplayReport(titleReport);

            var authorReport = manager.ReportByAuthor();
            Console.WriteLine("\n=== Report by Author ===");
            manager.DisplayReport(authorReport);

            var themeReport = manager.ReportByTheme();
            Console.WriteLine("\n=== Report by Theme ===");
            manager.DisplayReport(themeReport);

            manager.SaveReportToFile("theme_report.json", themeReport);

            manager.SaveToFile("poems.json");
            manager.LoadFromFile("poems.json");

            Console.WriteLine("\nFinished execution. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
