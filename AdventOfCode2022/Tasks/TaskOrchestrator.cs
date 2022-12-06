using AdventOfCode2022.Helpers;
using AdventOfCode2022.Models;
using AdventOfCode2022.Submarines;

namespace AdventOfCode2022.Tasks
{
    public static class TaskOrchestrator
    {
        public static void Task1()
        {
            Console.WriteLine("Test task 1");
        }

        public static void Task2()
        {
            var data = DataParserHelper.GetListOfTouple("data1.txt");
            var submarine = new SimpleSubmarine();
            submarine.HandleCommands(data);
            submarine.PrintPossition();
            Console.WriteLine(submarine.GetProductOfPossition());

            var advancedSubmarine = new AdvancedSubmarine();
            advancedSubmarine.HandleCommands(data);
            advancedSubmarine.PrintPossition();
            Console.Write(advancedSubmarine.GetProductOfPossition());
        }

        public static void Task5()
        {
            var total = 0;
            var lineDictionary = new Dictionary<Coordinate, int>();
            var data = DataParserHelper.GetListOfLines("data5.txt", false);
            foreach(var line in data)
            {
                foreach(var coordinate in line.GetCoordsOfLine())
                {
                    if (lineDictionary.ContainsKey(coordinate))
                        lineDictionary[coordinate]++;
                    else
                        lineDictionary.Add(coordinate, 1);
                }
            }
            foreach (var entry in lineDictionary)
            {
                if (entry.Value > 1)
                {
                    //Console.WriteLine($"X: {entry.Key.Xcoord}, Y: {entry.Key.Ycoord}, Value: {entry.Value}");
                    total++;
                }
            }
            Console.WriteLine($"Total number of crossing lines: {total}");
        }
    }
}
