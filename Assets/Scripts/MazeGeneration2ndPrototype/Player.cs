using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private MazeCell currentCell;
	private MazeDirection _currentDirection;
	private void Look(MazeDirection direction)
    {
		transform.localRotation = direction.ToRotation();
		_currentDirection = direction;
    }

	public void SetLocation(MazeCell cell)
	{
		if(currentCell != null)
        {
			currentCell.OnPlayerExited();
        }
		currentCell = cell;
		transform.localPosition = cell.transform.localPosition;
		currentCell.OnPlayerEntered();
	}

	private void Move(MazeDirection direction)
	{
		MazeCellEdge edge = currentCell.GetEdge(direction);
		if (edge is MazePassage)
		{
			SetLocation(edge.otherCell);
		}
	}

	private void Update()
	{
		//if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		//{
		//	Move(_currentDirection);
		//}
		//else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		//{
		//	Move(_currentDirection.GetNextClockwise());
		//}
		//else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		//{
		//	Move(_currentDirection.GetOpposite());
		//}
		//else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		//{
		//	Move(_currentDirection.GetNextCounterclockwise());
		//}
		//else if (Input.GetKeyDown(KeyCode.Q))
		//{
		//	Look(_currentDirection.GetNextCounterclockwise());
		//}
		//else if (Input.GetKeyDown(KeyCode.E))
		//{
		//	Look(_currentDirection.GetNextClockwise());
		//}
	}
}
