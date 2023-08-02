using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] allAlienSets;
    private GameObject currentSet;
    private Vector2 spawnPosition = new Vector2(0, 2.26f);
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SpawnNewWave();
    }
    public void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWawe());
    }
    IEnumerator SpawnWawe()
    {
        if (currentSet != null)
        {
            Destroy(currentSet);
        }
        yield return new WaitForSeconds(3);
        currentSet = Instantiate(allAlienSets[Random.Range(0, allAlienSets.Length)], spawnPosition, Quaternion.identity);
        UIManager.UpdateWave();
    }
}
