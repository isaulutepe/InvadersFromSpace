using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI hightScoreText;
    private int hightScore;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI waveText;
    private int wave;
    public Image[] liveSprites;
    public Image healthBar;
    public Sprite[] healthBars;
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
    public static void UpdateLives(int lives)
    {
        //Aktif ve inacktif durumunu renklerle kontrol edeceðiz.
        foreach (Image img in instance.liveSprites)
        {
            img.color = instance.inactive;
        }
        for (int i = 0; i < lives; i++)
        {
            instance.liveSprites[i].color = instance.active;
        }
    }
    public static void UpdateHealthBar(int i)
    {
        instance.healthBar.sprite = instance.healthBars[i];
    }
    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoreText.text=instance.score.ToString("000,000");
    }
    public static void UpdateHighScore()
    {

    }
    public static void UpdateWave()
    {
        instance.wave++;
        instance.waveText.text = instance.wave.ToString();
    }
    public static void UpdateCoins()
    {
        instance.coinText.text=Inventory.currentCoins.ToString();
    }

}