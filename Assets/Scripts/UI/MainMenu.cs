using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SizeSlider _sizeSlider;
    private void Awake()
    {
        _sizeSlider = GetComponent<SizeSlider>();
    }

}
