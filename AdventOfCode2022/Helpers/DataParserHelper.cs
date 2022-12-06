namespace AdventOfCode2022.Helpers
{
    public static class DataParserHelper
    {
        public static List<string> GetInputData(string fileName)
        {
            var data = GetData(fileName);
            return data.ToList();
        }
        private static string[] GetData(string fileName)
        {
            return File.ReadAllLines($"../../../DataInputs/{fileName}");
        }
    }
}
