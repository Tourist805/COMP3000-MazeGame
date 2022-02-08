using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] private MazeCell _cellPrefab;
    private MazeCell[,] cells;
    public float GenerationStepDelay;

    public IntVector2 size;
    public MazePassage PassagePrefab;
    public MazeWall WallPrefab;
    public IntVector2 RandomCoordinates
    {
        get
        {
            return new IntVector2(UnityEngine.Random.Range(0, size.x), UnityEngine.Random.Range(0, size.z));
        }
    }

    public bool ContainsCoordinates(IntVector2 coordinate)
    {
        return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
    }

    public MazeCell GetCell(IntVector2 coordinates)
    {
        return cells[coordinates.x, coordinates.z];
    }

    public IEnumerator Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(GenerationStepDelay);
        cells = new MazeCell[size.x, size.z];
        List<MazeCell> activeCells = new List<MazeCell>();
        DoFirstGenerationStep(activeCells);
        while(activeCells.Count > 0)
        {
            yield return delay;
            DoNextGenerationStep(activeCells);
        }
    }

    private void DoFirstGenerationStep(List<MazeCell> activeCells)
    {
        activeCells.Add(CreateCell(RandomCoordinates));
    }

    private void DoNextGenerationStep(List<MazeCell> activeCells)
    {
        int currentIndex = activeCells.Count - 1;
        MazeCell currentCell = activeCells[currentIndex];
        if (currentCell.IsFullyInitialized)
        {
            activeCells.RemoveAt(currentIndex);
            return;
        }
        MazeDirection direction = currentCell.RandomUninitializedDirection;
        IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
        if (ContainsCoordinates(coordinates))
        {
            MazeCell neighbor = GetCell(coordinates);
            if (neighbor == null)
            {
                neighbor = CreateCell(coordinates);
                CreatePassage(currentCell, neighbor, direction);
                activeCells.Add(neighbor);
            }
            else
            {
                CreateWall(currentCell, neighbor, direction);
                // No longer remove the cell here.
            }
        }
        else
        {
            CreateWall(currentCell, null, direction);
            // No longer remove the cell here.
        }
    }

    private MazeCell CreateCell(IntVector2 coordinates)
    {
        MazeCell cell = Instantiate(_cellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = cell;
        cell.coordinates = coordinates;
        cell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        cell.transform.parent = transform;
        cell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
        return cell;
    }

    private void CreatePassage(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        MazePassage passage = Instantiate(PassagePrefab) as MazePassage;
        passage.Initialize(cell, otherCell, direction);
        passage = Instantiate(PassagePrefab) as MazePassage;
        passage.Initialize(otherCell, cell, direction.GetOpposite());
    }

    private void CreateWall(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        MazeWall wall = Instantiate(WallPrefab) as MazeWall;
        wall.Initialize(cell, otherCell, direction);
        if(otherCell != null)
        {
            wall = Instantiate(WallPrefab) as MazeWall;
            wall.Initialize(otherCell, cell, direction.GetOpposite());
        }
    }
}
