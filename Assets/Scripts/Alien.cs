using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public int scoreValue;
    public GameObject explotions;
    //[SerializeField] private ObjectPool pool = null;
    private GameManager manager;
    public GameObject coinsPrefab;
    public GameObject healthPrefab;
    public GameObject lifePrefab;
    private const int LIFE_CHANCE = 1;
    private const int HEALTH_CHANCE = 10;
    private const int COIN_CHANCE = 50;




    public void Kill()
    {
        UIManager.UpdateScore(scoreValue);
        AlienMaster.allAliens.Remove(gameObject);
        Instantiate(explotions, transform.position, Quaternion.identity);
        int ran = Random.Range(0, 1000);
        if (ran <= LIFE_CHANCE)
        {
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        }
        else if (ran <= HEALTH_CHANCE)
        {
            Instantiate(healthPrefab, transform.position, Quaternion.identity);
        }
        else if (ran <= COIN_CHANCE)
            Instantiate(coinsPrefab, transform.position, Quaternion.identity);

        if (AlienMaster.allAliens.Count == 0)
        {
            manager.SpawnNewWave();
        }


        gameObject.SetActive(false);

    }

}
