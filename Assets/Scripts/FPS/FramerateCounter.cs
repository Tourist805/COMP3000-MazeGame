using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FramerateCounter : MonoBehaviour
{
    private int _frameCounter = 0;
    private float _timeCounter = 0.0f;
    private float _refreshTime = 0.1f;

    private float _maxFramerate = 0f;
    private float _minFramerate = 1000f;

    [SerializeField] private TMPro.TMP_Text _framerateText;
    [SerializeField] private TMPro.TMP_Text _minFramerateText;
    [SerializeField] private TMPro.TMP_Text _maxFramerateText;

    private void Start()
    {
        StartCoroutine(ResetMinFramerate());
    }

    private IEnumerator ResetMinFramerate()
    {
        yield return new WaitForSeconds(1f);
        _minFramerate = 1000f;
    }

    private void Update()
    {
        if(_timeCounter < _refreshTime)
        {
            _timeCounter += Time.deltaTime;
            _frameCounter++;
        }
        else
        {
            float lastFramerate = _frameCounter / _timeCounter;
            if (_minFramerate > lastFramerate)
                _minFramerate = lastFramerate;
            if (_maxFramerate < lastFramerate)
                _maxFramerate = lastFramerate;
            _frameCounter = 0;
            _timeCounter = 0.0f;
            _framerateText.text = "Framerate: " + lastFramerate.ToString("n2");
            _minFramerateText.text = "Min Framerate: " + _minFramerate.ToString("n2");
            _maxFramerateText.text = "Max Framerate: " + _maxFramerate.ToString("n2");
        }
    }
}
