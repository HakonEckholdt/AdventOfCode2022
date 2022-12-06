using AdventOfCode2022.Models;

namespace AdventOfCode2022.Helpers
{
    public static class DataParserHelper
    {
        public static List<(string command, int value)> GetListOfTouple(string fileName)
        {
            var result = new List<(string command, int value)>();
            var data = GetData(fileName);
            foreach (string line in data)
            {
                var lineComponents = line.Split();
                result.Add((lineComponents[0], int.Parse(lineComponents[1])));
            }
            return result;
        }

        public static List<string> GetInputData(string fileName)
        {
            var result = new List<Line>();
            var data = GetData(fileName);
            return data.ToList();
        }

        public static List<Line> GetListOfLines(string fileName, bool allowDiagonal)
        {
            var result = new List<Line>();
            var data = GetData(fileName);
            foreach (string line in data)
            {
                var lineComponents = line.Split(" -> ");
                var startComponents = lineComponents[0].Split(",").Select(x => int.Parse(x)).ToList();
                var endComponents = lineComponents[1].Split(",").Select(x => int.Parse(x)).ToList();
                var lineObject = new Line(new Coordinate(startComponents[0], startComponents[1]), new Coordinate(endComponents[0], endComponents[1]));
                if (allowDiagonal || (lineObject.Start.Xcoord == lineObject.End.Xcoord || lineObject.Start.Ycoord == lineObject.End.Ycoord))
                    result.Add(lineObject);
            }
            return result!;
        }

        private static string[] GetData(string fileName)
        {
            return File.ReadAllLines($"../../../DataInputs/{fileName}");
        }
    }
}
