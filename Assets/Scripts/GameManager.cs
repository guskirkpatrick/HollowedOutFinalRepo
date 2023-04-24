using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameOver = false;
    private UIManager UI;
    public bool paused = false;
    [SerializeField] private GameObject Player;
 

    void Start()
    {
        gameOver = false;
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        //Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            //resume
            Time.timeScale = 1;  //100% of fps

        }
        else if (paused) {
            Time.timeScale = 0; //0fps
        }

            if (Input.GetKeyDown(KeyCode.P))
            {

            if (paused)
                paused = false;
            else
                paused = true;
           
            }
        
        if (gameOver==true)
        {
            paused = true;
           // Player.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
                gameOver = false;
                UI.GameOverDisplay.SetActive(false);
                //UI.HideTitle();
            }
        }
    }
}
