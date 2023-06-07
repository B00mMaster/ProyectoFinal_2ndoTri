using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public static string playerName;
    

    public void SaveName()
    {
       

        GameManager.Instance.playerName = nameInputField.text;
        
    }
}
