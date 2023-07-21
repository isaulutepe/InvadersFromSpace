using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    
    public float destroyTime;

    private void Start()
    {
       // Destroy(gameObject,destroyTime);
    }
    private void Update()
    {
        if (transform.position.y> 7f)
        {
            gameObject.SetActive(false);
        }
    }
}
