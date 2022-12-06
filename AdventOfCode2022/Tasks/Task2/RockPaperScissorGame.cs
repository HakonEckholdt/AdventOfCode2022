namespace AdventOfCode2022.Tasks.Task2
{
    public class RockPaperScissorGame
    {
        public GameAction OpponentAction { get; set; }
        public GameAction PlayerAction { get; set; }

        public RockPaperScissorGame(string gameInput)
        {
            if (gameInput.StartsWith("A"))
                OpponentAction = GameAction.Rock;
            else if (gameInput.StartsWith("B"))
                OpponentAction = GameAction.Paper;
            else
                OpponentAction = GameAction.Scissor;
            if (gameInput.EndsWith("X"))
                PlayerAction = GameAction.Rock;
            else if (gameInput.EndsWith("Y"))
                PlayerAction = GameAction.Paper;
            else
                PlayerAction = GameAction.Scissor;
        }

        public RockPaperScissorGame(bool isversion2, string gameInput)
        {
            if (gameInput.StartsWith("A"))
                OpponentAction = GameAction.Rock;
            else if (gameInput.StartsWith("B"))
                OpponentAction = GameAction.Paper;
            else
                OpponentAction = GameAction.Scissor;
            if (gameInput.EndsWith("X"))
                SetGameActionToLose();
            else if (gameInput.EndsWith("Y"))
                PlayerAction = OpponentAction;
            else
                SetGameActionToWin();
        }

        private void SetGameActionToWin()
        {
            if (OpponentAction == GameAction.Rock)
                PlayerAction = GameAction.Paper;
            else if (OpponentAction == GameAction.Paper)
                PlayerAction = GameAction.Scissor;
            else PlayerAction = GameAction.Rock;
        }
        private void SetGameActionToLose()
        {
            if (OpponentAction == GameAction.Rock)
                PlayerAction = GameAction.Scissor;
            else if (OpponentAction == GameAction.Paper)
                PlayerAction = GameAction.Rock;
            else PlayerAction = GameAction.Paper;
        }

        public int PlayerScore()
        {
            switch (PlayerAction)
            {
                case GameAction.Rock:
                    if (OpponentAction == GameAction.Scissor)
                        return 1 + 6;
                    else if (OpponentAction == GameAction.Paper)
                        return 1;
                    return 1 + 3;
                case GameAction.Paper:
                    if (OpponentAction == GameAction.Rock)
                        return 2 + 6;
                    else if (OpponentAction == GameAction.Scissor)
                        return 2;
                    return 2 + 3;
                case GameAction.Scissor:
                    if (OpponentAction == GameAction.Paper)
                        return 3 + 6;
                    else if (OpponentAction == GameAction.Rock)
                        return 3;
                    return 3 + 3;
                default: throw new NotImplementedException();
            }   
        }
    }


    public enum GameAction
    {
        Rock,
        Paper,
        Scissor
    }
}
