using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    private const float MAX_LEFT = -6F;
    private float speed = 5f;
    public int scoreValue;
    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x<=MAX_LEFT)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            UIManager.UpdateScore(scoreValue);
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
