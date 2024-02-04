using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement : MonoBehaviour
{
    #region Unity Public
    public GameObject[] PaternPoints;
    public GameObject Enemie;
    public float speed = 1;
    public bool Cam = false;
    #endregion

    private GameObject LastPoint;

    void Start()
    {
        float Step = speed * Time.deltaTime;
        LastPoint = PaternPoints[0];
        Enemie.transform.position = Vector3.MoveTowards(Enemie.transform.position, PaternPoints[0].transform.position, Step);
    }

    void Update()
    {
        if (!Cam)
        {
            Enemie.SetActive(false);
        }
        else
        {
            Enemie.SetActive(true);
            foreach (GameObject point in PaternPoints)
            {
                float Step = speed * Time.deltaTime;
                if (LastPoint.transform.position == Enemie.transform.position && point == LastPoint)
                {
                    int index = Array.IndexOf(PaternPoints, point);
                    if (index + 1 < PaternPoints.Length)
                    {
                        Enemie.transform.position = Vector3.MoveTowards(Enemie.transform.position, PaternPoints[index + 1].transform.position, Step);
                        LastPoint = PaternPoints[index + 1];
                    }
                    else
                    {
                        Enemie.transform.position = Vector3.MoveTowards(Enemie.transform.position, PaternPoints[0].transform.position, Step);
                        LastPoint = PaternPoints[0];
                    }
                }
                else
                {
                    Enemie.transform.position = Vector3.MoveTowards(Enemie.transform.position, LastPoint.transform.position, Step);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Cam = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Cam = false;
        }
    }
}
