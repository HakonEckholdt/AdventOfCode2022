namespace AdventOfCode2022.Tasks.Task7
{
    public class ProgramExecuter
    {
        public FileSystemNode RootNode { get; }
        public FileSystemNode ActiveDirectory { get; set; }
        public int TotalDiskSpace = 70000000;
        public int RequiredFreeDiskSpace = 30000000;
        public int FreeDiskSpace { get; set; }

        public ProgramExecuter(FileSystemNode rootNode)
        {
            RootNode = rootNode;
            ActiveDirectory = rootNode;
        }

        public void ExecuteDataLine(string data)
        {
            var splitData = data.Split();
            if (data.Contains("$ cd .."))
            {
                ActiveDirectory = ActiveDirectory.Parent;
                return;
            } else if (data.Contains("$ cd")) {
                ActiveDirectory = ActiveDirectory.Children.Where(child => child.Name == splitData[2]).First();
                return;
            } else if (data.Contains("$"))
            {
                return;
            }
            else if (data.Contains("dir"))
            {
                ActiveDirectory.AddChildDir(splitData[1]);
            } else
            {
                ActiveDirectory.AddFile(splitData[1], int.Parse(splitData[0]));
            }
        }

        public void PrintStructure()
        {
            PrintFromNodes(new List<FileSystemNode>() { RootNode });
        }

        private void PrintFromNodes(List<FileSystemNode>? nodes, string startLine = "")
        {
            if (nodes == null)
                return;
            startLine += "   ";
            foreach (var node in nodes)
            {
                var postFix = "(" + ((node.Type == NodeType.File) ? node.Size.ToString() + ", " : "") + node.Type.ToString() + ")";
                var dirSize = (node.Type == NodeType.Dir && node.TotalNodeSize > 0) ? "( " + node.TotalNodeSize.ToString() + " )": "";
                if (node.TotalNodeSize < 100000 && node.TotalNodeSize > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(startLine + $"- {node.Name} {postFix} {dirSize}");
                Console.ResetColor();
                PrintFromNodes(node.Children, startLine);
            }
        }

        private int GetTotalValueRecursively(int maxValue, int currentTotal, FileSystemNode node)
        {
            var newTotal = 0;
            foreach(var child in node.Children)
            {
                if (child.TotalNodeSize < maxValue)
                {
                    newTotal += child.TotalNodeSize;
                }
                var tempTotal = GetTotalValueRecursively(maxValue, currentTotal, child);
                newTotal += tempTotal;
            }
            return newTotal;
        }

        public int GetTotalFileStructureSizeRecursively(List<FileSystemNode> nodes)
        {
            var totalSize = 0;
            foreach(var child in nodes)
            {
                if (child.Type == NodeType.File)
                    totalSize += child.Size;
                else
                    totalSize += GetTotalFileStructureSizeRecursively(child.Children);
            }
            return totalSize;
        }

        public void PrintAllDirsWithMaxSize(int maxSize)
        {
            RootNode.GetTotalNodeSize();
            var total = GetTotalValueRecursively(maxSize, 0, RootNode);
            Console.WriteLine($"Found directories with size smaler than {maxSize}. Total Size {total}");
        }

        public void SetFreeDiskSpace()
        {
            RootNode.GetTotalNodeSize();
            FreeDiskSpace = TotalDiskSpace - GetTotalFileStructureSizeRecursively(RootNode.Children);
        }

        public int GetSmallestToDelete(List<FileSystemNode> nodes)
        {
            var needToDelete = RequiredFreeDiskSpace - FreeDiskSpace;
            int currentMinSize = int.MaxValue;
            foreach (var child in nodes)
            {
                if (child.TotalNodeSize > needToDelete && child.TotalNodeSize < currentMinSize)
                {
                    currentMinSize = child.TotalNodeSize;
                    var tempMinSize = GetSmallestToDelete(child.Children);
                    if (tempMinSize < currentMinSize)
                    {
                        currentMinSize = tempMinSize;
                    }
                }
            }
            return currentMinSize;
        }
    }

    public enum Actiontype
    {
        cd,
        ls
    }
}
