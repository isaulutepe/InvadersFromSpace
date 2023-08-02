using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    Camera cam;
    public float width;
    private float speed = 3f;
    bool isShoting;
    float coolDown = 0.5f;

    [SerializeField] private ObjectPool objectPool = null;
    public Ship ShipStats;
    private Vector2 offScreanPos = new Vector2(0, -20f);
    private Vector2 startPos = new Vector2(0, -6.5f);

    private float directionX;
    private void Awake()
    {
        cam = Camera.main;
        width = ((1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f) / 2) - 0.25f); //Geminin boyutunu ekranda kaplad��� alandan ��kartt�k, daha do�ru bir sonuc almak i�in
    }
    private void Start()
    {
        ShipStats.currentHealth = ShipStats.maxHealth;
        ShipStats.currentLifes = ShipStats.maxLifes;
        ShipStats.currentLifes = 3;
        UIManager.UpdateHealthBar(ShipStats.currentHealth);
        UIManager.UpdateLives(ShipStats.currentLifes);
    }
    private void Update()
    {


#if UNITY_EDITOR //Yap�lan de�i�ikli�in UnityEditor i�inde oldugunu belirtmeki�in kullan�lan bir y�ntemdir
        //E�er sadece unity editorse Update i�inde bu kodlar �al��acak;
        if (Input.GetKey(KeyCode.A) && transform.position.x > -width)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < width)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Space) && !isShoting)
        {
            StartCoroutine(Shoot());
        }

#endif
        //Gyro sensor kullan�m� i�in yap�lan bir i�lem.(Telefonu sa�a sola yat�rarak hareket ettirmek i�in)
        directionX = Input.acceleration.x;
        //Debug.Log(directionX);
        if (directionX <= -0.1f && transform.position.x > -width)
        {
            transform.Translate(Vector2.left * Time.deltaTime * ShipStats.shipSpeed);
        }
        if (directionX >= 0.1f && transform.position.x < width)
        {
            transform.Translate(Vector2.right * Time.deltaTime * ShipStats.shipSpeed);
        }
        //
    }

    //Ekrana t�kland���nda ate� etmek i�in yap�lmas� gerekenler
    public void ShootButton()
    {
        if (!isShoting)
        {
            StartCoroutine(Shoot());
        }
    }
    private IEnumerator Shoot()
    {
        isShoting = true;
        //  Instantiate(bulletPrefab, transform.position, Quaternion.identity); //A��sal bir de�i�iklik olmad�g� i�in oldugu gibi burada olu�aca��ndan Quantern�on �dentity kulland�k.
        GameObject obj = objectPool.GetPollObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(coolDown); //Ate� etmek i�in belli bir s�re beklemesini istiyoruz sonra devam edebilir hale gelecektir
        isShoting = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player Hit");
            collision.gameObject.SetActive(false);//EnemyBullet kapatt�k
            TakeDamege();
        }
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreanPos; //Karakteri ekran�n d���na ald�k, art�k g�r�nm�yor respown oldu�unda geri gelecek.
        yield return new WaitForSeconds(2);
        ShipStats.currentHealth = ShipStats.maxHealth;
        transform.position = startPos;
        UIManager.UpdateHealthBar(ShipStats.currentHealth);

    }
    private void TakeDamege()
    {
        ShipStats.currentHealth--;

        UIManager.UpdateHealthBar(ShipStats.currentHealth);

        if (ShipStats.currentHealth <= 0)
        {
            ShipStats.currentLifes--;
            UIManager.UpdateLives(ShipStats.currentLifes);

            Debug.Log(ShipStats.currentLifes);

            if (ShipStats.currentLifes <= 0)
            {
                Debug.Log("GameOver");
            }
            else
            {
                Debug.Log("Respawn");
                StartCoroutine(Respawn());
            }
        }
    }
    public void AddHealth()
    {
        if (ShipStats.currentHealth ==ShipStats.maxHealth)
        {
            UIManager.UpdateScore(250);
        }
        else
        {
            ShipStats.currentHealth++;
            UIManager.UpdateHealthBar(ShipStats.currentHealth);
        }
    }
    public void AddLife()
    {
        if (ShipStats.currentLifes == ShipStats.maxLifes)
        {
            UIManager.UpdateScore(1000);
        }
        else
        {
            ShipStats.currentLifes++;
            UIManager.UpdateLives(ShipStats.currentLifes);
        }
    }
}
