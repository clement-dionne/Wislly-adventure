using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnim : MonoBehaviour
{
    #region Unity Public
    public GameObject WaterTile1;
    public GameObject WaterTile2;
    public GameObject WaterTile3;

    public float AnimSpeed = 1f;
    #endregion

    #region Unity Private
    private bool AnimeWait = false;
    private bool Cam = false;
    #endregion

    void Start()
    {
        WaterTile1.SetActive(true);
        WaterTile2.SetActive(false);
        WaterTile3.SetActive(false);
    }

    void Update()
    {
        if (!AnimeWait && Cam)
        {
            StartCoroutine(WaterAnimation());
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

    public IEnumerator WaterAnimation()
    {
        AnimeWait = true;

        WaterTile1.SetActive(true);
        WaterTile2.SetActive(false);
        WaterTile3.SetActive(false);
        yield return new WaitForSeconds(1);
        WaterTile1.SetActive(false);
        WaterTile2.SetActive(true);
        WaterTile3.SetActive(false);
        yield return new WaitForSeconds(1);
        WaterTile1.SetActive(false);
        WaterTile2.SetActive(false);
        WaterTile3.SetActive(true);
        yield return new WaitForSeconds(1);

        AnimeWait = false;
    }
}