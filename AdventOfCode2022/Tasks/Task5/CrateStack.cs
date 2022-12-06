namespace AdventOfCode2022.Tasks.Task5
{
    public class CrateStack
    {
        public List<string> Crates { get; set; }

        public CrateStack(List<string> crates)
        {
            Crates = crates;
        }

        public List<string> TakeCrates(int numberOfCrates)
        {
            var crateLenght = Crates.Count;
            var toTake = Crates.Skip(Crates.Count - numberOfCrates).ToList();
            Crates = Crates.SkipLast(numberOfCrates).ToList();
            return toTake;
        }

        public void PlaceCrates(List<string> crates)
        {
            crates.Reverse();
            Crates.AddRange(crates);
        }

        public void PlaceCratesSameOrder(List<string> crates)
        {
            Crates.AddRange(crates);
        }
    }
}
