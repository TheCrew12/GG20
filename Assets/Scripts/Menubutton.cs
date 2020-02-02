using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menubutton : MonoBehaviour
{
    private void Start() 
    {
        this.GetComponent<Button>().onClick.AddListener(ClickedEVENT);
    }

    public void ClickedEVENT()
    {
        SceneManager.LoadScene(1);
    }
}
