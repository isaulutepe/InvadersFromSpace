using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class AlienMaster : MonoBehaviour
{
    private ObjectPool pool = null;
    private ObjectPool motherShippool = null;
    public GameObject bulletPrefab;
    private Vector3 horizontalMoveDistanece = new Vector3(0.05f, 0, 0);
    private Vector3 verticalMoveDistance = new Vector3(0, 0.15f, 0);
    private Player playerScript;
    private float width;
    private const float MAX_LEFT = -4f;
    private const float MAX_RIGHT = 4f;
    private const float MAX_MOVE_SPEED = 0.02F;
    public static List<GameObject> allAliens = new List<GameObject>(); //Bütün alienlarý bvir listede tutacaðýz
    private bool moveingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;
    private float ShootTimer = 3f;
    private const float shotTime = 3f;

    public GameObject motherShipPrefab;
    private Vector3 MOtherShipSpawnPosition = new Vector3(6, 5f, 0);
    private float MotherShipTimer =60f;
    private const float MotherShipMinTime = 15f;
    private const float MotherShipMaxTime = 60f;
    private const float START_Y = 1.7f;
    private bool entering = true;



    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(obj);
        }
    }
    private void Update()
    {
        if (entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10f);
            if (transform.position.y<=START_Y)
            {
                entering = false;
            }
        }
        else
        {
            if (moveTimer <= 0)
            {
                MoveEnemies();
            }
            if (ShootTimer <= 0)
            {
                Shoot();
            }
            if (MotherShipTimer <= 0)
                SpawnMotherShip();
            moveTimer -= Time.deltaTime;
            ShootTimer -= Time.deltaTime;
            MotherShipTimer -= Time.deltaTime;
        }
     
    }

    private void Shoot()
    {
        Vector2 pos = allAliens[UnityEngine.Random.Range(0, allAliens.Count)].transform.position;
        GameObject obh = pool.GetPollObject();
        obh.transform.position = pos;
        ShootTimer = shotTime;
    }

    public void MoveEnemies()
    {
        int hitMax = 0;
        for (int i = 0; i < allAliens.Count; i++)
        {
            if (moveingRight)
            {
                allAliens[i].transform.position += horizontalMoveDistanece;

            }
            else
            {
                allAliens[i].transform.position -= horizontalMoveDistanece;
            }
            if (allAliens[i].transform.position.x > MAX_RIGHT || allAliens[i].transform.position.x < MAX_LEFT)
            {
                hitMax++;
            }
        }
        if (hitMax > 0)
        {
            for (int i = 0; i < allAliens.Count; i++)
            {
                allAliens[i].transform.position -= verticalMoveDistance;
            }
            moveingRight = !moveingRight;
        }
        moveTimer = GetMovedSpeed();
    }
    private float GetMovedSpeed()
    {
        float f = allAliens.Count * moveTime;
        if (f < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }
    private void SpawnMotherShip()
    {
        GameObject obj = motherShippool.GetPollObject();
        obj.transform.position = MOtherShipSpawnPosition;
        MotherShipTimer = UnityEngine.Random.Range(MotherShipMinTime, MotherShipMaxTime);

    }
}
