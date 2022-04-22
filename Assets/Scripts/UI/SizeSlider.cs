using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : MonoBehaviour
{
    [SerializeField] private Slider _lengthSlider;
    [SerializeField] private Slider _widthSlider;
    [SerializeField] private TMPro.TMP_Text _lengthText;
    [SerializeField] private TMPro.TMP_Text _widthText;
    private int _length, _width;


    private void Update()
    {
        _lengthText.text = "Length: " + _lengthSlider.value;
        _length = Mathf.FloorToInt(_lengthSlider.value);
        _widthText.text = "Width: " + _widthSlider.value;
        _width = Mathf.FloorToInt(_widthSlider.value);
        Debug.Log("Length: " + _length + " Width: " + _width);
    }
}
