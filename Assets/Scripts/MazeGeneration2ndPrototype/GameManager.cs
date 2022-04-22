using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze MazePrefab;
    private Maze _mazeInstance;
    public Player PlayerPrefab;
    [SerializeField] private Enemy[] _enemyPrefabs;
    private Enemy[] _enemies;

    private Player _playerInstance;

    [SerializeField] private StatsCanvas _statsCanvas;
    private void Start()
    {
        _enemies = new Enemy[_enemyPrefabs.Length];
        StartCoroutine(BeginGame());
    }

    private void Update()
    {
    
    }

    private IEnumerator BeginGame()
    {
        Camera.main.clearFlags = CameraClearFlags.Skybox;
        Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        Debug.Log("Maze Length: " + PlayerPrefs.GetInt(PrefsStorage.MAZE_LENGTH + " Maze Width: " + PrefsStorage.MAZE_WIDTH));
        _mazeInstance = Instantiate(MazePrefab) as Maze;
        yield return StartCoroutine(_mazeInstance.Generate());
        _playerInstance = Instantiate(PlayerPrefab) as Player;
        _playerInstance.SetLocation(_mazeInstance.GetCell(_mazeInstance.RandomCoordinates));
        Camera.main.clearFlags = CameraClearFlags.Depth;
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
        _statsCanvas.ActivateStats();

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            //_currentEnemyIntance = Instantiate(_enemyPrefab) as Enemy;
            _enemies[i] = Instantiate(_enemyPrefabs[i]) as Enemy;
            var gameobject = _enemies[i].gameObject;
            _enemies[i].SetLocation(_mazeInstance.GetCell(_mazeInstance.RandomCoordinates));
            _enemies[i].gameObject.SetActive(true);
        }
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
