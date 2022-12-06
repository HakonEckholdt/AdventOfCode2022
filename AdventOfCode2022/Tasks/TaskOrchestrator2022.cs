using AdventOfCode2022.Helpers;
using AdventOfCode2022.Tasks.Task1;
using AdventOfCode2022.Tasks.Task2;
using AdventOfCode2022.Tasks.Task3;
using AdventOfCode2022.Tasks.Task4;
using AdventOfCode2022.Tasks.Task5;
using AdventOfCode2022.Tasks.Task6;

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
    }
}
