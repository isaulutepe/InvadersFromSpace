using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 horizontalMoveDistanece = new Vector3(0.05f, 0, 0);
    private Vector3 verticalMoveDistance = new Vector3(0, 0.15f, 0);
    private const float MAX_LEFT = -2f;
    private const float MAX_RIGHT = 2f;
    private const float MAX_MOVE_SPEED = 0.02F;
    private List<GameObject> allAliens = new List<GameObject>(); //Bütün alienlarý bvir listede tutacaðýz
    private bool moveingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(obj);
        }
    }
    private void Update()
    {
        if (moveTimer <= 0)
        {
            MoveEnemies();
        }
        moveTimer -= Time.deltaTime;
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
        moveTimer=GetMovedSpeed();
    }
    private float GetMovedSpeed()
    {
        float f = allAliens.Count * moveTime;
        if (f <MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }

}
