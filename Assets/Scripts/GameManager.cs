using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameOver = false;
    //static?
    private UIManager UI;
    private player PL;

    public bool paused = false;
    [SerializeField] private GameObject Player;
 

    void Start()
    {
        gameOver = false;
       // if(EyeBalls== null)
       // EyeBalls = GameObject.Find("player").GetComponent<EyePupilL>();
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        PL = Player.GetComponent<player>();
        //Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
        PauseCheck();
        if (gameOver==true)
        {
            UI.SetGameOver(true);

            paused = true;
        //add a pp effect
           
        }
    }

    void PauseCheck()
    {
        if (!paused)
        {
            //resume
            Time.timeScale = 1;  //100% of fps
            UI.SetPauseMenu(false);

        }
        else if (paused)
        {
            UI.SetPauseMenu(true);
            Time.timeScale = 0; //0fps
        }

        if (Input.GetKeyDown(KeyCode.P)|| Input.GetKeyDown(KeyCode.Escape))
        {

            if (paused)
                paused = false;
            else
                paused = true;

        }
    }
}
