using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public static class DailyDiary
    {
       public static string _filePath = Path.Combine(Environment.CurrentDirectory, "mydiary.txt");



        static DailyDiary()
        {

            
            if (!File.Exists(_filePath)) {
                Console.WriteLine("meow");
                
            }
        }

       

        public static string[] ReadFile()
        {
            string[] entries = File.ReadAllLines(_filePath);
            foreach (string entry in entries) {
                Console.WriteLine(entry);
            }
            return entries;
        }

        public static bool WriteFile(string _filePath, DateTime date, string content)
        {
            try
            {
                var entry = new Entry(date, content);
                var entryText = entry.ToString();
                File.AppendAllText(_filePath, entryText + Environment.NewLine + Environment.NewLine);
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
                return false; 
            }
        }

        public static void DeleteSpecific(string input)
        {
            var entries = ReadEntries();
            List<Entry> updatedEntries;

            if (DateTime.TryParse(input, out DateTime date))
            {
                updatedEntries = entries.Where(e => e.Date != date).ToList();
            }
            else
            {
                updatedEntries = entries.Where(e => !e.Content.Contains(input)).ToList();
            }

            WriteEntriesToFile(updatedEntries);
        }

        public static void CountLines()
        {
            var count = ReadEntries().Count;
            Console.WriteLine($"Total entries: {count}");
        }
        public static void SearchFile(Func<Entry, bool> criteria)
        {
            var entries = ReadEntries();
            var searchResults = entries.Where(criteria).ToList();

            foreach (var entry in searchResults)
            {
                Console.WriteLine(entry);
            }
        }

        private static List<Entry> ReadEntries()
        {
            var entries = new List<Entry>();
            var lines = File.ReadAllLines(_filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                if (DateTime.TryParse(lines[i], out DateTime date))
                {
                    var content = new List<string>();
                    i++;
                    while (i < lines.Length && !DateTime.TryParse(lines[i], out _))
                    {
                        content.Add(lines[i]);
                        i++;
                    }
                    i--;
                    entries.Add(new Entry(date, string.Join(Environment.NewLine, content)));
                }
            }

            return entries;
        }

        private static void WriteEntriesToFile(List<Entry> entries)
        {
            var lines = entries.Select(e => e.ToString()).ToArray();
            File.WriteAllLines(_filePath, lines);
        }

    }
}
