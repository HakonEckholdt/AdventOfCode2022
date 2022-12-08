﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Tasks
{
    public class TreeGrid
    {
        public int[,] TreeMatrix { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public TreeGrid(List<string> data)
        {
            Width = data[0].ToCharArray().Length;
            Height = data.Count();
            TreeMatrix = new int[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                var dataline = data[i].ToCharArray().ToList();
                for (int j = 0; j < Width; j++)
                {
                    TreeMatrix[j, i] = int.Parse(dataline[j].ToString());
                }
            }
        }

        public int TreesInPerimiter()
        {
            return (Height * 2) + (Width * 2) - 4;
        }

        public int FindMaxInnerSceenicScore()
        {
            var count = 0;
            for (int i = 1; i < Height - 1; i++)
            {
                for (int j = 1; j < Width - 1; j++)
                {
                    if (CanBeSeen(j, i))
                        count++;
                }
            }
            return count;
        }

        public int CountOfInnerTreesThatCanBeSeen()
        {
            var count = 0;
            for (int i = 1; i < Height - 1; i++)
            {
                for (int j = 1; j < Width - 1; j++)
                {
                    if (CanBeSeen(j, i))
                        count++;
                }
            }
            return count;
        }

        public bool CanBeSeen(int width, int height)
        {
            if (CanSeeFromBottom(width, height))
                return true;
            else if (CanSeeFromTop(width, height))
                return true;
            else if (CanSeeFromLeft(width, height))
                return true;
            else if (CanSeeFromRight(width, height))
                return true;
            return false;

        }

        public bool CanSeeFromLeft(int width, int height)
        {
            var treeToTest = TreeMatrix[width, height];
            for (var i = width-1; i >= 0; i--)
            {
                var test = TreeMatrix[i, height];
                if (treeToTest > TreeMatrix[i, height])
                    continue;
                return false;
            }
            return true;
        }

        public bool CanSeeFromRight(int width, int height)
        {
            var treeToTest = TreeMatrix[width, height];
            for (var i = width + 1; i <= Width-1; i++)
            {
                if (treeToTest > TreeMatrix[i, height])
                    continue;
                return false;
            }
            return true;
        }

        public bool CanSeeFromTop(int width, int height)
        {
            var treeToTest = TreeMatrix[width, height];
            for(var i = height-1; i >= 0; i--)
            {
                if (treeToTest > TreeMatrix[width, i])
                    continue;
                return false;
            }
            return true;
        }

        public bool CanSeeFromBottom(int width, int height)
        {
            var treeToTest = TreeMatrix[width, height];
            for (var i = height + 1; i <= Height-1; i++)
            {
                if (treeToTest > TreeMatrix[width, i])
                    continue;
                return false;
            }
            return true;
        }



        public void PrintTreeMatrix()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(TreeMatrix[j, i].ToString());
                }
                Console.Write("\n");
            }
        }
    }
}
