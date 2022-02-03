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

    public IEnumerator Generate()
    {
        WaitForSeconds delay = new WaitForSeconds(GenerationStepDelay);
        cells = new MazeCell[size.x, size.z];
        //IntVector2 coordinates = RandomCoordinates;
        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                yield return delay;
                CreateCell(new IntVector2(x, z));
            }
        }
    }

    private void CreateCell(IntVector2 coordinates)
    {
        MazeCell cell = Instantiate(_cellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = cell;
        cell.coordinates = coordinates;
        cell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        cell.transform.parent = transform;
        cell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
    }
}
