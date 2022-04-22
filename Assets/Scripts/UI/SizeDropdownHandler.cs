using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeDropdownHandler : MonoBehaviour
{
    private TMPro.TMP_Text _textBox;

    private void Start()
    {
        var dropdown = GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("20 X 20");
        items.Add("30 X 30");
        //items.Add()
    }

    private void FillDropdown()
    {

    }
}
