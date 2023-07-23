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
    //RGBA Deðerlerinin hepsine eriþerek kullanabilmek için color32 kullandýk.
    private Color32 active =new Color(1,1,1,1);
    private Color32 inactive = new Color(1, 1, 1, 0.25f);

    private void Awake()
    {
        //BU iþleme singleton adý verilir : Bu oyunda varsa tekrar oluþyuturulmayacak ve silinecek, yoksa oluþturulacaktýr.
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