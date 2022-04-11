using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Maze MazePrefab;
    private Maze _mazeInstance;
    public Player PlayerPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _enemiesNumber;
    private Enemy _currentEnemyIntance;
    private List<Enemy> _enemiesInstances;

    private Player _playerInstance;

    [SerializeField] private StatsCanvas _statsCanvas;
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
        Camera.main.rect = new Rect(0f, 0f, 0.5f, 0.5f);
        _statsCanvas.ActivateStats();
        for (int i = 0; i < _enemiesNumber; i++)
        {
            _currentEnemyIntance = Instantiate(_enemyPrefab) as Enemy;
            _currentEnemyIntance.SetLocation(_mazeInstance.GetCell(_mazeInstance.RandomCoordinates));
            _enemiesInstances.Add(_currentEnemyIntance);
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
