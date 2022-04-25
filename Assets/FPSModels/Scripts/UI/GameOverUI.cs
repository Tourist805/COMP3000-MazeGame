using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _scoreText;
    private bool _isOpened = false;
    [SerializeField] private TMPro.TMP_Text _messageText;
    private bool _winningCondition = false;

    private void OnEnable()
    {
        PlayerHealth.PlayerDead += Open;
    }

    private void OnDisable()
    {
        PlayerHealth.PlayerDead -= Open;
    }


    public void SetCondition(bool condition)
    {
        _winningCondition = condition;
    }

    private void SetMessage()
    {
        if(_winningCondition)
        {
            _messageText.text = "Congratulations";
        }
        else
        {
            _messageText.text = "Unlucky";
        }
    }

    public void Open()
    {
        SetMessage();
        gameObject.SetActive(true);
        _scoreText.text = "Score: " + Coin.Count.ToString();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        Debug.Log("Return to menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartLevel()
    {
        Debug.Log("Restart level");
        ConditionObserver.GameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
