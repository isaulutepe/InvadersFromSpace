using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    
    public float destroyTime;

    private void Start()
    {
        Destroy(gameObject,destroyTime);
    }
}
