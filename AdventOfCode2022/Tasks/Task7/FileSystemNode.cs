namespace AdventOfCode2022.Tasks.Task7
{
    public class FileSystemNode
    {
        public int TotalNodeSize { get; set; }
        public NodeType Type { get; set; }
        public int Size { get; set; }
        public string Name { get; set; }
        public FileSystemNode Parent { get; set; }
        public List<FileSystemNode> Children { get; set; } = new List<FileSystemNode>();

        public FileSystemNode(FileSystemNode parent, string name, int size)
        {
            Type = NodeType.File;
            Parent = parent;
            Size = size;
            Name = name;
        }

        public FileSystemNode(FileSystemNode parent, string name)
        {
            Type = NodeType.Dir;
            Parent = parent;
            Name = name;
        }

        public FileSystemNode AddChildDir(string name) 
        {
            var newNode = new FileSystemNode(this, name);
            Children.Add(newNode);
            return newNode;
        }

        public FileSystemNode AddFile(string name, int size)
        {
            var newNode = new FileSystemNode(this, name, size);
            Children.Add(newNode);
            return newNode;
        }

        public int GetTotalNodeSize()
        {
            int nodeSize = 0;
            if (Children.Count == 0)
                return Size;
            foreach(var child in Children)
            {
                nodeSize += child.GetTotalNodeSize();
            }
            TotalNodeSize = nodeSize;
            return nodeSize;
        }
    }

    public enum NodeType
    {
        File,
        Dir
    }
}
