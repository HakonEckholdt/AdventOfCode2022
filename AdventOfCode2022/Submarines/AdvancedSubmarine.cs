using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Submarines
{
    public class AdvancedSubmarine
    {
        public int _horizontalPosition;
        public int _verticalPosition;
        public int _aim;

        public AdvancedSubmarine(int horizontalPosition = 0, int verticalPosition = 0, int aim = 0)
        {
            _horizontalPosition = horizontalPosition;
            _verticalPosition = verticalPosition;
            _aim = aim;
        }

        public int GetProductOfPossition()
        {
            return _horizontalPosition * _verticalPosition;
        }

        public void PrintPossition()
        {
            Console.WriteLine($"Vertical possition: {_verticalPosition}, and Horizontal possition: {_horizontalPosition}");
        }

        public void HandleCommands(List<(string command, int value)> commandList)
        {
            foreach (var command in commandList)
            {
                switch (command.command)
                {
                    case "up":
                        Up(command.value);
                        break;
                    case "down":
                        Down(command.value);
                        break;
                    case "forward":
                        Forward(command.value);
                        break;
                }
            }
        }

        private void Up(int change)
        {
            _aim -= change;
        }

        private void Down(int change)
        {
            _aim += change;
        }

        private void Forward(int distance)
        {
            _horizontalPosition += distance;
            _verticalPosition += distance * _aim;
        }
    }
}
