using Daily_Diary;
namespace DiaryManagerTests

{
    public class UnitTest1
    {



        [Fact]
        public void ReadFile_ShouldReturnEntries()
        {
            string _filePath = Path.Combine(Environment.CurrentDirectory, "mydiary.txt");
            string[] expceted = DailyDiary.ReadFile();
            string[] data = File.ReadAllLines(_filePath);
            Assert.Equal(expceted.Length, data.Length);
        }

        [Fact]
        public void WriteFile_ShouldWriteEntryToFile()
        {
            string _filePath = Path.Combine(Environment.CurrentDirectory, "testFile.txt");
            DateTime testDate = DateTime.Now;
            string testContent = "Test Content";
            bool success = DailyDiary.WriteFile(_filePath, testDate, testContent);
            Assert.True(success);
        }
    }
}