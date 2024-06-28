namespace Daily_Diary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DailyDiary.WriteFile(DailyDiary._filePath , DateTime.Now, "Test TEst TETAT AST Meow" );
            DailyDiary.ReadFile();
            DailyDiary.CountLines();

            Console.WriteLine("\nSearch Results:");
            DailyDiary.SearchFile(entry => entry.Content.Contains("diary"));

            Console.WriteLine("\nDeleting entries containing 'diary'");
            DailyDiary.DeleteSpecific("diary");
            Console.WriteLine("Entries after deletion:");
            DailyDiary.ReadFile();

        }
    }
}
