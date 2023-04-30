using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseMenu : MonoBehaviour
{
    private player PL;
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        
    GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        PL = GameObject.Find("player").GetComponent<player>();
}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resume()
    {
        GM.paused = false;
    }
    public void restart()
    {
        PL.reset();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
