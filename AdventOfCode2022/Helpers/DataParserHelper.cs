using AdventOfCode2022.Tasks.Task3;

namespace AdventOfCode2022.Helpers
{
    public static class DataParserHelper
    {
        public static List<string> GetInputData(string fileName)
        {
            var data = GetData(fileName);
            return data.ToList();
        }

        public static List<List<char>> GetCharMatrix(string filename)
        {
            var data = GetInputData(filename);
            var matrix = new List<List<char>>();
            foreach (var line in data)
            {
                matrix.Add(line.ToCharArray().ToList());
            }
            return matrix;
        }

        public static List<List<int>> GetIntFromString(string filename)
        {
            var newMatrix = new List<List<int>>();
            var stringMatrix = GetCharMatrix(filename);
            foreach(var row in stringMatrix)
            {
                var newRow = new List<int>();
                foreach(var col in row)
                {
                    newRow.Add(Dicts.RuckSackItemValues[col] - 1);
                }
                newMatrix.Add(newRow);
            }
            return newMatrix;
        }
        private static string[] GetData(string fileName)
        {
            return File.ReadAllLines($"../../../DataInputs/{fileName}");
        }
    }
}
