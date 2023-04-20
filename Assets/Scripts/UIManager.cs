using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //import for UI/Image


public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text LifeDisplay;
    [SerializeField] private Text BulletDisplay;
   

    [SerializeField] private GameObject TitleScreen;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    public void UpdateLives(int currentLives)
    {
        LifeDisplay.text = "Lives: " + currentLives;
    }
    public void UpdateBullets(int bullets)
    {
        BulletDisplay.text = "Bullets: " + bullets;
    }

}
