using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menubutton : MonoBehaviour
{
    private void Start() 
    {
        GetComponent<Button>().onClick.AddListener(ClickedEVENT);
    }

    private void ClickedEVENT()
    {
        SceneManager.LoadScene(1);
    }
}
