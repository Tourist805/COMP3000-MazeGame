using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(MazeConstructor))]
public class GameController : MonoBehaviour
{
    [SerializeField] private FpsMovement _player;
    [SerializeField] private Text _timeLabel;
    [SerializeField] private Text _scoreLabel;
    
    private MazeConstructor _mazeConstructor;

    private DateTime _startTime;
    private int _timeLimit;
    private int _reduceLimitBy;

    private int _score;
    private bool _goalReached;

    private void Start()
    {
        _mazeConstructor = GetComponent<MazeConstructor>();
        _mazeConstructor.GenerateNewMaze(25, 31);
    }

    private void StartGame()
    {
        _timeLimit = 80;
        _reduceLimitBy = 5;
        _startTime = DateTime.Now;

        _score = 0;
        _scoreLabel.text = _score.ToString();
    }
}
