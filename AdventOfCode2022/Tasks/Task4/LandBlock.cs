namespace AdventOfCode2022.Tasks.Task4
{
    public class ElfPair
    {
        public LandBlock FirstElfLand { get; set; }
        public LandBlock SecondElfLand { get; set; }

        public ElfPair(string data)
        {
            var dataSplit = data.Split(',');
            FirstElfLand = new LandBlock(dataSplit[0]);
            SecondElfLand = new LandBlock(dataSplit[1]);
        }

        public bool AnyOverlap()
        {
            return FirstElfLand.LandList.Intersect(SecondElfLand.LandList).Any();
        }

        public bool OneFullyCoinatinsOther()
        {
            var intersection = FirstElfLand.LandList.Intersect(SecondElfLand.LandList);
            return SecondElfLand.LandList.Count() == intersection.Count() || FirstElfLand.LandList.Count() == intersection.Count();
        }
    }

    public class LandBlock
    {
        public List<int> LandList { get; set; } = new List<int>();

        public LandBlock(string data)
        {
            var dataSplit = data.Split('-');
            for (var i = int.Parse(dataSplit[0]); i <= int.Parse(dataSplit[1]); i++)
            {
                LandList.Add(i);
            }
        }
    }
}
