using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDataGenerator 
{
    public float PlacementThreshold;

    public MazeDataGenerator()
    {
        PlacementThreshold = 0.1f;
    }

    public int[,] FromDimensions(int numRows, int numCols)
    {
        int[,] maze = new int[numRows, numCols];
        int maximumRows = maze.GetUpperBound(0);
        int maximumCols = maze.GetUpperBound(1);

        for (int i = 0; i <= maximumRows; i++)
        {
            for (int j = 0; j <= maximumCols; j++)
            {
                if (i == 0 || j == 0 || i == maximumRows || j == maximumCols)
                {
                    maze[i, j] = 1;
                }
                else if(i % 2 == 0 && j % 2 == 0)
                {
                    if(Random.value > PlacementThreshold)
                    {
                        maze[i, j] = 1;

                        int rowOffset = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                        int colOffset = rowOffset != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                        maze[i + rowOffset, j + colOffset] = 1;
                    }
                }
            }
        }
        return maze;
    }
}
