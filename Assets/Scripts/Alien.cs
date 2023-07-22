using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public int scoreValue;
    public GameObject explotions;
    [SerializeField] private ObjectPool pool = null;


    public void Kill()
    {

        AlienMaster.allAliens.Remove(gameObject);
        Instantiate(explotions, transform.position, Quaternion.identity);
        gameObject.SetActive(false);

    }

}
