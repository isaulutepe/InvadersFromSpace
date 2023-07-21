using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pooledObject; //5 adet nesne olacak ve arka arkaya olacaklarý için b,r kuyruk oluþturduk
    [SerializeField] private GameObject objectPrefab; //Havuzdaki obje-objeler
    public int poolSize; //Havuz boyutu
    private void Awake()
    {
        pooledObject = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObject.Enqueue(obj);
        }
    }
    public GameObject GetPollObject()
    {
        GameObject obj=pooledObject.Dequeue();
        obj.SetActive(true);
        pooledObject.Enqueue(obj);
        return obj;
    }
}
