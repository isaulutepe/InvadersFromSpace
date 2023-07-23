using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    private TextMeshProUGUI scoreText;
    private int score;
    private TextMeshProUGUI hightScoreText;
    private int hightScore;
    private TextMeshProUGUI coinText;
    private TextMeshProUGUI waveText;
    private int wave;
    private Image[] liveSprites;
    private Image healthBar;
    private Sprite[] healthBars;
    //RGBA De�erlerinin hepsine eri�erek kullanabilmek i�in color32 kulland�k.
    private Color32 active =new Color(1,1,1,1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    private void Awake()
    {
        //BU i�leme singleton ad� verilir : Bu oyunda varsa tekrar olu�yuturulmayacak ve silinecek, yoksa olu�turulacakt�r.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void UpdateLives(int i)
    {

    }
    public static void UpdateHealthBar(int i)
    {

    }
    public static void UpdateScore()
    {

    }
    public static void UpdateHighScore()
    {

    }
    public static void UpdateWave()
    {

    }
    public static void UpdateCoins()
    {
    }

}