using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endUI;
    public Text endMessage;
    public static GameManager Instance;
    private EnemySpawner enemySpawner;
    void Awake()
    {
        Instance = this;
        enemySpawner = GetComponent<EnemySpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "SUCCESSFULLY DEFENDED!";
    }
    public void Lose()
    {
        enemySpawner.Stop();
        endUI.SetActive(true);
        endMessage.text = "WE CAN DO BETTER";
    }
    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
