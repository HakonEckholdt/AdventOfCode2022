namespace AdventOfCode2022.Tasks.Task1
{
    public static class Task1Helper
    {
        public static List<Elf> GetTopThree(List<Elf> elfs)
        {
            var top3Elfs = new List<Elf>();
            var currentMin = 0;
            foreach (var elf in elfs)
            {
                if(elf.TotalCalories > currentMin)
                {
                    top3Elfs.Add(elf);
                    if (top3Elfs.Count == 4)
                        top3Elfs.Remove(elfs.Where(x => x.TotalCalories == currentMin).First());
                    if (top3Elfs.Count == 3)
                        currentMin = top3Elfs.Min(elf => elf.TotalCalories);
                }
            }
            return top3Elfs;
        }
    }
}
