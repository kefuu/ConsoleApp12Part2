using Newtonsoft.Json;

namespace ConsoleApp12Part2
{
    public class Poem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearOfWriting { get; set; }
        public string Text { get; set; }
        public string Theme { get; set; }
    }

    public class PoemManager
    {
        private List<Poem> poems;

        public PoemManager()
        {
            poems = new List<Poem>();
        }

        public void AddPoem(Poem poem)
        {
            poems.Add(poem);
        }

        public void DeletePoem(Poem poem)
        {
            poems.Remove(poem);
        }

        public void UpdatePoem(Poem oldPoem, Poem newPoem)
        {
            int index = poems.IndexOf(oldPoem);
            if (index != -1)
            {
                poems[index] = newPoem;
            }
        }

        public IEnumerable<Poem> Search(Func<Poem, bool> predicate)
        {
            return poems.FindAll(new Predicate<Poem>(predicate));
        }

        public void SaveToFile(string filename)
        {
            var json = JsonConvert.SerializeObject(poems);
            File.WriteAllText(filename, json);
        }

        public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                poems = JsonConvert.DeserializeObject<List<Poem>>(json);
            }
        }

        public List<Poem> ReportByTitle()
        {
            return poems.OrderBy(p => p.Title).ToList();
        }

        public List<Poem> ReportByAuthor()
        {
            return poems.OrderBy(p => p.Author).ToList();
        }

        public List<Poem> ReportByTheme()
        {
            return poems.OrderBy(p => p.Theme).ToList();
        }

        public void DisplayReport(List<Poem> report)
        {
            foreach (var poem in report)
            {
                Console.WriteLine($"Title: {poem.Title}, Author: {poem.Author}, Year: {poem.YearOfWriting}, Theme: {poem.Theme}");
                Console.WriteLine($"Text: {poem.Text}\n");
            }
        }

        public void SaveReportToFile(string filename, List<Poem> report)
        {
            var json = JsonConvert.SerializeObject(report);
            File.WriteAllText(filename, json);
        }
    }
}
