using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    [SerializeField] private GameObject _pauseMenuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && (ConditionObserver.GameHasEnded == false))
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void DestroyWindow()
    {
        
    }

    public void ActivateMenu()
    {
        Coin.Count = 0;
        ConditionObserver.GameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
    private void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
