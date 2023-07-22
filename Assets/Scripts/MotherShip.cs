using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    private const float MAX_LEFT = -6F;
    private float speed = 5f;
    private void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x<=MAX_LEFT)
        {
            gameObject.SetActive(false);
        }
    }
}
