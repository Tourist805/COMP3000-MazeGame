using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SizeSlider _sizeSlider;
    private void Awake()
    {
        _sizeSlider = GetComponent<SizeSlider>();
    }

    private void Update()
    {
        Debug.Log("Length: " + _sizeSlider.Length + " Width: " + _sizeSlider.Width);
    }

    public void Play()
    {
        PlayerPrefs.SetInt(PrefsStorage.MAZE_LENGTH, _sizeSlider.Length);
        PlayerPrefs.SetInt(PrefsStorage.MAZE_WIDTH, _sizeSlider.Width);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
