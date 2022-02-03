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
        StartGame();
    }

    private void StartGame()
    {
        _timeLimit = 80;
        _reduceLimitBy = 5;
        _startTime = DateTime.Now;

        _score = 0;
        // _scoreLabel.text = _score.ToString();
        InitializeMaze();
    }

    private void InitializeMaze()
    {
        _mazeConstructor.GenerateNewMaze(25, 31, OnStartTrigger, OnGoalTrigger);

        float x = _mazeConstructor.StartCol * _mazeConstructor.HallWidth;
        float y = 1;
        float z = _mazeConstructor.StartCol * _mazeConstructor.HallWidth;
        _player.transform.position = new Vector3(x, y, z);

        _goalReached = false;
        _player.enabled = true;

        _timeLimit -= _reduceLimitBy;
        _startTime = DateTime.Now;
    }
    private void Update()
    {
        if(_player.enabled)
        {
            return;
        }

        int timeUsed = (int)(DateTime.Now - _startTime).TotalSeconds;
        int timeLeft = _timeLimit - timeUsed;

        if(timeLeft > 0)
        {

        }
        else
        {
            _player.enabled = false;
            Invoke("StartGame", 4);
        }
    }
    private void OnGoalTrigger(GameObject trigger, GameObject other)
    {
        Debug.Log("Goal");
        _goalReached = true;

        _score += 1;
        Destroy(trigger);
    }

    private void OnStartTrigger(GameObject trigger, GameObject other)
    {
        if(_goalReached)
        {
            Debug.Log("Finished");
            _player.enabled = false;

            Invoke("InitializeMaze", 4);
        }
    }
}
