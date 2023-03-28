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

  //  [SerializeField] private GameObject PauseText;

    void Start()
    {
        gameOver = false;
        UI = GameObject.Find("Canvas").GetComponent<UIManager>();
        //Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                //resume
                Time.timeScale = 1;  //100% of fps
                paused = false;
               // PauseText.SetActive(false);
            }
            else
            {
                //pause
                Time.timeScale = 0; //0fps
                paused = true;
              //  PauseText.SetActive(true);
            }
        }
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
             //  Player.transform
                //add player 
                gameOver = false;
                UI.HideTitle();
            }
        }
    }
}
