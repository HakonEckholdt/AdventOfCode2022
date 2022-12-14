using AdventOfCode2022.Helpers;
using AdventOfCode2022.Tasks.Task1;
using AdventOfCode2022.Tasks.Task10;
using AdventOfCode2022.Tasks.Task11;
using AdventOfCode2022.Tasks.Task12;
using AdventOfCode2022.Tasks.Task2;
using AdventOfCode2022.Tasks.Task3;
using AdventOfCode2022.Tasks.Task4;
using AdventOfCode2022.Tasks.Task5;
using AdventOfCode2022.Tasks.Task6;
using AdventOfCode2022.Tasks.Task7;
using AdventOfCode2022.Tasks.Task9;

namespace AdventOfCode2022.Tasks
{
    public static class TaskOrchestrator2022
    {
        public static void Task1()
        {
            Console.WriteLine("Test task 1");
            var data = DataParserHelper.GetInputData("data1_22.txt");
            int i = 0;
            var elfs = new List<Elf>();
            var elf = new Elf(i);
            foreach (var line in data)
            {
                if (line == "")
                {
                    i++;
                    elfs.Add(elf);
                    elf = new Elf(i);
                    continue;
                }
                elf.Inventory.Add(int.Parse(line));
            }
            elfs.Add(elf);
            elfs.ForEach(elf => elf.CalculateTotalCalories());
            var bestElf = elfs.Where(elf => elf.TotalCalories == elfs.Max(x => x.TotalCalories)).First();
            var top3BestElfs = Task1Helper.GetTopThree(elfs);
            Console.WriteLine($"Best elf is elf {bestElf.Id}, with {bestElf.TotalCalories} calories!!");
            Console.WriteLine($"The top three elves are carying {top3BestElfs.Sum(x => x.TotalCalories)} calories");
        }

        public static void Task2()
        {
            var data = DataParserHelper.GetInputData("data2_22.txt");
            var tournament = new RockPaperScissorTournament(data);
            var tournament2 = new RockPaperScissorTournament(true, data);
            tournament.CalulateTotalScore();
            tournament2.CalulateTotalScore();
            Console.WriteLine($"TotalScore for player is {tournament.TotalScore}");
            Console.WriteLine($"TotalScore for player in V2 is {tournament2.TotalScore}");
        }

        public static void Task3()
        {
            var data = DataParserHelper.GetInputData("data3_22.txt");
            var RuckSacks = data.Select(line => new RuckSack(line)).ToList();
            var totalError = RuckSacks.Sum(sack => sack.GetCommonItemValue());
            
            var currentTotalOfBadges = 0;
            for (var i = 0; i < RuckSacks.Count()/3; i++)
            {
                var items1 = RuckSacks[i * 3].CompleteInventory;
                var items2 = RuckSacks[i * 3 + 1].CompleteInventory;
                var items3 = RuckSacks[i * 3 + 2].CompleteInventory;
                currentTotalOfBadges += Dicts.RuckSackItemValues[items1.Intersect(items2).Intersect(items3).First()];
            }
            Console.WriteLine($"Total Item ErrorValue is {totalError}");
            Console.WriteLine($"Total BadgeValues is {currentTotalOfBadges}");
        }

        public static void Task4()
        {
            var data = DataParserHelper.GetInputData("data4_22.txt");
            var elfPairs = new List<ElfPair>();
            foreach (var dataLine in data)
            {
                elfPairs.Add(new ElfPair(dataLine));
            }
            var test = elfPairs.Where(x => x.OneFullyCoinatinsOther());
            var fullyContained = elfPairs.Where(elfpair => elfpair.OneFullyCoinatinsOther()).Count();
            var anyOverlapp = elfPairs.Count(elfPair => elfPair.AnyOverlap());
            Console.WriteLine($"One Elfs land fully contin another in {fullyContained} cases");
            Console.WriteLine($"One elfs land overlap at all in {anyOverlapp} cases");
        }

        public static void Task5()
        {
            var data = DataParserHelper.GetInputData("data5_22.txt").Skip(10).ToList();
            var ship = new ShipToEmpty(new List<CrateStack>() {
                new CrateStack(new List<string>() { "[H]", "[T]", "[Z]", "[D]" }),
                new CrateStack(new List<string>() { "[Q]", "[R]", "[W]", "[T]", "[G]", "[C]", "[S]" }),
                new CrateStack(new List<string>() { "[P]", "[B]", "[F]", "[Q]", "[N]", "[R]", "[C]", "[H]" }),
                new CrateStack(new List<string>() { "[L]", "[C]", "[N]", "[F]", "[H]", "[Z]" }),
                new CrateStack(new List<string>() { "[G]", "[L]", "[F]", "[Q]", "[S]" }),
                new CrateStack(new List<string>() { "[V]", "[P]", "[W]", "[Z]", "[B]", "[R]", "[C]", "[S]" }),
                new CrateStack(new List<string>() { "[Z]", "[F]", "[J]" }),
                new CrateStack(new List<string>() { "[D]", "[L]", "[V]", "[Z]", "[R]", "[H]", "[Q]" }),
                new CrateStack(new List<string>() { "[B]", "[H]", "[G]", "[N]", "[F]", "[Z]", "[L]", "[D]" })
            });
            ship.PrintShip();
//            ship.MakeMoves(data.Select(row => new Move(row)).ToList());
            ship.MakeMoves2(data.Select(row => new Move(row)).ToList());
            ship.PrintShip();
            ship.PrintMessage();
        }

        public static void Task6()
        {
            Console.WriteLine("Paste string to decode");
            var comunicationString = Console.ReadLine() ?? "";
            Console.WriteLine("How many unique letters?");
            var uniqueLetters = int.Parse(Console.ReadLine());

            var letterNumber = Decoder.GetFirstMarkerPosition(comunicationString, uniqueLetters, out var markerOut);
            Console.WriteLine($"Found marker: {markerOut} with {uniqueLetters} unique letters after {letterNumber} letters");

        }

        public static void Task7()
        {
            var data = DataParserHelper.GetInputData("data7_22.txt").Skip(1).ToList();
            var rootNode = new FileSystemNode(null, "/");
            var filesystem = new ProgramExecuter(rootNode);
            foreach(var dataLine in data)
            {
                filesystem.ExecuteDataLine(dataLine);
            }
            //filesystem.PrintStructure();
            //filesystem.PrintAllDirsWithMinSize(100000);
            filesystem.PrintAllDirsWithMaxSize(100000);
            filesystem.SetFreeDiskSpace();
            var smallestDeletable = filesystem.GetSmallestToDelete(rootNode.Children);
            Console.WriteLine($"The smallest directory that is large enough is {smallestDeletable} byte large");
        }

        public static void Task8()
        {
            var data = DataParserHelper.GetInputData("data8_22.txt");
            var treeGrid = new TreeGrid(data);
            treeGrid.PrintTreeMatrix();
            var count = treeGrid.CountOfInnerTreesThatCanBeSeen();
            var outer = treeGrid.TreesInPerimiter();
            var score = treeGrid.FindMaxInnerSceenicScore();

            Console.WriteLine($"{count}, {outer}, total: {count + outer}, Score = {score}");
        }

        public static void Task9()
        {
            var data = DataParserHelper.GetInputData("data9_22.txt");
            Console.WriteLine("How many knots in Rope? (number)");
            var numberOfKnots = int.Parse(Console.ReadLine());
            var rope = new Rope(numberOfKnots);
            rope.ExecuteInput(data);
            rope.PrintTailLog();
        }

        public static void Task10()
        {
            var data = DataParserHelper.GetInputData("data10_22.txt");
            var crt = new CRT();
            crt.ExecuteCRTProgram(data);
            crt.PrintCycleRegisterValueLog();
            crt.PrintScreen();
        }

        public static void Task11()
        {
            var data = DataParserHelper.GetInputData("data11_22.txt");
            var currentMonkeyData = new List<string>();

            Console.WriteLine("How many rounds should the monkeys throw items? (number)");
            var numberOfRounds = int.Parse(Console.ReadLine());
            var monkeyRing = new MonkeyRing(data);
            monkeyRing.ExecuteMonkeyRing(numberOfRounds);
            monkeyRing.PrintAllPassings();
            monkeyRing.PrintLevelOfMonkeyBussiness();
        }

        public static void Task12()
        {
            var data = DataParserHelper.GetIntFromString("data12_22.txt");
            var startX = data.FindIndex(x => x.Contains(44));
            var startY = data[startX].FindIndex(y => y == 44);
            var endX = data.FindIndex(x => x.Contains(30));
            var endY = data[endX].FindIndex(y => y == 30);
            data[endX][endY] = 25;
            var algorithm = new Astar(startX, startY, endX, endY, data);
            algorithm.Solve();
            var possibleStarts = new List<(int x, int y)>();
            for(var row = 0; row < data.Count; row++)
            {
                for(var col = 0; col < data[0].Count; col ++)
                {
                    var height = data[row][col];
                    
                    if (height == 0)
                    {
                        possibleStarts.Add((row, col));
                    }
                }
            }
            var currentLowest = int.MaxValue;
            var tracker = 0;
            foreach(var start in possibleStarts)
            {
                algorithm = new Astar(start.x, start.y, endX, endY, data);
                var currentVal = algorithm.Solve();
                if (currentVal < currentLowest)
                {
                    currentLowest = currentVal;
                    Console.WriteLine(currentLowest);
                }
                tracker++;
                if (tracker%10==0)
                {
                    Console.WriteLine($"{((tracker* 100) / possibleStarts.Count)}% done");
                }
                
            }
            Console.WriteLine("Done");
            Console.WriteLine(currentLowest);
        }
    }
}
