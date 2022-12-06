using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Submarines
{
    public class SimpleSubmarine
    {
        public int _horizontalPosition;
        public int _verticalPosition;

        public SimpleSubmarine(int horizontalPosition = 0, int verticalPosition = 0)
        {
            _horizontalPosition = horizontalPosition;
            _verticalPosition = verticalPosition;
        }

        public int GetProductOfPossition()
        { 
            return _horizontalPosition*_verticalPosition;
        }

        public void PrintPossition()
        {
            Console.WriteLine($"Vertical possition: {_verticalPosition}, and Horizontal possition: {_horizontalPosition}");
        }

        public void HandleCommands(List<(string command, int value)> commandList)
        {
            foreach(var command in commandList)
            {
                switch(command.command)
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

        private void Up(int distance)
        {
            _verticalPosition -= distance;
        }

        private void Down(int distance)
        {
            _verticalPosition += distance;
        }

        private void Forward(int distance)
        {
            _horizontalPosition += distance;
        }
    }
}
