using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ship : MonoBehaviour
{
    [Range(1, 5)] //Bir aral�k tan�mlad�k
    public int maxHealth;
    [HideInInspector] //SerializeField nas�l de�eri g�steriyorsssa bu da de�per gizlememize yarayan bir fonksiyondur.
    public int currentHealth;
    [HideInInspector]
    public int maxLifes=3; //karakterin 3 can� olacak kalkanlar k�r�l�nca art�k ya�amayacak o kontrol� sa�lamak i�in bu fde�i�keni olu�turduk.
    [HideInInspector]
    public int currentLifes=3;


    public float shipSpeed;
    public float fireRate;
}
