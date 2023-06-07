using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameText;

        private void Start()
        {
       

        string displayText = $"You WIN " + GameManager. Instance. playerName;

        nameText.text = displayText;
        }
}
