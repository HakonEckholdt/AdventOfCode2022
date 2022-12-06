namespace AdventOfCode2022.Tasks.Task2
{
    public class RockPaperScissorTournament
    {
        public List<RockPaperScissorGame> Games { get; set; } = new List<RockPaperScissorGame>();
        public int TotalScore { get; set; }

        public RockPaperScissorTournament(List<string> gameDataList)
        {
            foreach (var gameData in gameDataList)
            {
                Games.Add(new RockPaperScissorGame(gameData));
            }
        }
        public RockPaperScissorTournament(bool isVersion2, List<string> gameDataList)
        {
            foreach (var gameData in gameDataList)
            {
                Games.Add(new RockPaperScissorGame(true, gameData));
            }
        }

        public void CalulateTotalScore()
        {
            TotalScore = Games.Sum(game => game.PlayerScore());
        }
    }
}
