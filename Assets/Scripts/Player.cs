using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        cam = Camera.main;
        width = ((1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f) / 2) - 0.25f); //Geminin boyutunu ekranda kaplad��� alandan ��kartt�k, daha do�ru bir sonuc almak i�in
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
    }
    private IEnumerator Shoot()
    {
        isShoting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity); //A��sal bir de�i�iklik olmad�g� i�in oldugu gibi burada olu�aca��ndan Quantern�on �dentity kulland�k.
        yield return new WaitForSeconds(coolDown); //Ate� etmek i�in belli bir s�re beklemesini istiyoruz sonra devam edebilir hale gelecektir
        isShoting = false;
    }
}
