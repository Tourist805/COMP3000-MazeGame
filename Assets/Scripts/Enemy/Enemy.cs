using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private MazeCell currentCell;

	public void SetLocation(MazeCell cell)
	{
		if (currentCell != null)
		{
			currentCell.OnPlayerExited();
		}
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		currentCell.OnPlayerEntered();
	}
}
