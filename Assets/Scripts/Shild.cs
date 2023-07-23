using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Shild : MonoBehaviour
{
    public Sprite[] states;
    private int health;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        health = 4;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("FrinedlyBullet")) 
        {
            collision.gameObject.SetActive(false);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                spriteRenderer.sprite = states[health - 1];
            }
        }
    }
}
