using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OnStartGamel1()
    {
        SceneManager.LoadScene(2);
    }
    public void OnStartGamel2()
    {
        SceneManager.LoadScene(3);
    }
    public void OnStartGamel3()
    {
        SceneManager.LoadScene(4);
    }
    public void OnQuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        #endif
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
