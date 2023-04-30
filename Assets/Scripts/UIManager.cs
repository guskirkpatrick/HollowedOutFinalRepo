 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //import for UI/Image
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text LifeDisplay;
    [SerializeField] private Text BulletDisplay;
    [SerializeField] private Text ScoreDisplay;
    [SerializeField] public GameObject GameOverDisplay;
   
    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject PauseMenu;
    private player PL;
    private GameManager GM;
    // [SerializeField] private GameObject Player;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        PL = GameObject.Find("player").GetComponent<player>();
    }

   
    public void HideTitle()
    {
        TitleScreen.SetActive(false);
        UpdateLives(3);

    }
    public void ShowTitle()
    {
        TitleScreen.SetActive(true);
    }
    public void SetGameOver(bool bo)
    {
        GameOverDisplay.SetActive(bo);
    }
   
    public void SetPauseMenu(bool bo)
    {
        PauseMenu.SetActive(bo);
    }
    public void UpdateLives(int currentLives)
    {
        LifeDisplay.text = "Lives: " + currentLives;
    }
    public void UpdateBullets(int bullets)
    {
        BulletDisplay.text = "Bullets: " + bullets;
    }
    public void UpdateScore(int score)
    {
        ScoreDisplay.text = "Score: " + score;
    }


}
