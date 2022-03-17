using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze MazePrefab;
    private Maze _mazeInstance;
    public Player PlayerPrefab;

    private Player _playerInstance;
    private void Start()
    {
        StartCoroutine(BeginGame());
    }

    private void Update()
    {
    
    }

    private IEnumerator BeginGame()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        _mazeInstance = Instantiate(MazePrefab) as Maze;
        yield return StartCoroutine(_mazeInstance.Generate());
        _playerInstance = Instantiate(PlayerPrefab) as Player;
        _playerInstance.SetLocation(_mazeInstance.GetCell(_mazeInstance.RandomCoordinates));
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, 0.25f, 0.25f);
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(_mazeInstance.gameObject);
        if (_playerInstance != null)
        {
            Destroy(_playerInstance.gameObject);
        }
        StartCoroutine(BeginGame());
    }
}
