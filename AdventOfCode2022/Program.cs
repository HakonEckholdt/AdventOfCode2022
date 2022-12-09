using AdventOfCode2022.Tasks;

namespace AdventOfCode2022
{
    public class Program
    {
        private static Dictionary<int, (string name, Action action)> MenuItems = new Dictionary<int, (string name, Action action)>
        {
            {1, (name: "Oppgave 1", action: () =>  TaskOrchestrator2022.Task1())},
            {2, (name: "Oppgave 2", action: () => TaskOrchestrator2022.Task2())},
            {3, (name: "Oppgave 3", action: () => TaskOrchestrator2022.Task3())},
            {4, (name: "Oppgave 4", action: () => TaskOrchestrator2022.Task4())},
            {5, (name: "Oppgave 5", action: () => TaskOrchestrator2022.Task5())},
            {6, (name: "Oppgave 6", action: () => TaskOrchestrator2022.Task6())},
            {7, (name: "Oppgave 7", action: () => TaskOrchestrator2022.Task7())},
            {8, (name: "Oppgave 8", action: () => TaskOrchestrator2022.Task8())},
            {9, (name: "Oppgave 9", action: () => TaskOrchestrator2022.Task9())}
        };

        public static void Main(string[] args)
        {
            while (true)
            {
                foreach (var menuItem in MenuItems)
                {
                    if (menuItem.Key % 100 == 0)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(menuItem.Key + ". " + menuItem.Value.name);
                }
                Console.WriteLine("X. Avslutt");

                var command = Console.ReadLine();
                Console.WriteLine();
                if (command?.ToLower() == "x")
                    break;
                if (int.TryParse(command, out var cmd) && MenuItems.ContainsKey(cmd))
                {
                    MenuItems[cmd].action.Invoke();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ugyldig kommando");
                }

            }

            Console.WriteLine("Avslutter..");
        }
    }
}