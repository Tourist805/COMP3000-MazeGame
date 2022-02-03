using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze MazePrefab;
    private Maze _mazeInstance;
    private void Start()
    {
        BeginGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        _mazeInstance = Instantiate(MazePrefab) as Maze;
        StartCoroutine(_mazeInstance.Generate());
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(_mazeInstance.gameObject);
        BeginGame();
    }
}
