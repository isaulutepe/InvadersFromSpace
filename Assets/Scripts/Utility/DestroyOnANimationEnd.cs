using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnANimationEnd : MonoBehaviour
{
    public float delay;
    private void Start()
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length +delay);
        //Animasyonun uzunluðunu al ve o kadar süre bekledikten sonra destroy et
    }
}
