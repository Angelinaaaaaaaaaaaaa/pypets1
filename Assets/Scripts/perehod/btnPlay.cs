using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnPlay : MonoBehaviour
{
    public GameObject panel;

    public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
    
   
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Выход");
        
    }

    public void Show()
    {
        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
