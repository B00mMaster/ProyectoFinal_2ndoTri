using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Navegar : MonoBehaviour
{
    public void GoToScene(int idx)
    {
        SceneManager.LoadScene(idx);
    }

}
