using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    public float speed=5f;

    private void Update()
    {
        transform.Translate(Vector3.up* Time.deltaTime *   speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(" "))
        {

        }
    }
}
