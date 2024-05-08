using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{

    void Start()
    {
        
    }

   
    void Update()
    {

    }

    public void Play(){
        SceneManager.LoadScene("GamePlay");
    }

    public void Quit(){
        Application.Quit();
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
