using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ship : MonoBehaviour
{
    [Range(1, 5)] //Bir aralýk tanýmladýk
    public int maxHealth;
    [HideInInspector] //SerializeField nasýl deðeri gösteriyorsssa bu da deðper gizlememize yarayan bir fonksiyondur.
    public int currentHealth;
    [HideInInspector]
    public int maxLifes=3; //karakterin 3 caný olacak kalkanlar kýrýlýnca artýk yaþamayacak o kontrolü saðlamak için bu fdeðiþkeni oluþturduk.
    [HideInInspector]
    public int currentLifes=3;


    public float shipSpeed;
    public float fireRate;
}
