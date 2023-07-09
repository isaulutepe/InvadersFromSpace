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
        width = ((1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f) / 2) - 0.25f); //Geminin boyutunu ekranda kapladýðý alandan çýkarttýk, daha doðru bir sonuc almak için
    }
    private void Update()
    {


#if UNITY_EDITOR //Yapýlan deðiþikliðin UnityEditor içinde oldugunu belirtmekiçin kullanýlan bir yöntemdir
        //Eðer sadece unity editorse Update içinde bu kodlar çalýþacak;
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
        Instantiate(bulletPrefab, transform.position, Quaternion.identity); //Açýsal bir deðiþiklik olmadýgý için oldugu gibi burada oluþacaðýndan Quanternþon Ýdentity kullandýk.
        yield return new WaitForSeconds(coolDown); //Ateþ etmek için belli bir süre beklemesini istiyoruz sonra devam edebilir hale gelecektir
        isShoting = false;
    }
}
