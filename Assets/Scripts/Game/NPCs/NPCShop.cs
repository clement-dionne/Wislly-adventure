using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    #region Unity Public
    public string NPCname;
    public GameObject ShopPanel;
    public Text NPCnameText;
    public bool InRange = false;

    public GameObject PlayerGameObject;

    public Animator NPCanimation;
    public GameObject PausePanel;
    #endregion

    #region Private
    private bool Waiting;
    #endregion

    void Start()
    {
        ShopPanel.SetActive(false);
        InRange = false;
        Waiting = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!ShopPanel.activeInHierarchy && InRange && !Waiting)
            {
                ShopPanel.SetActive(true);
                PlayerGameObject.GetComponent<PlayersController>().enabled = false;
                StartCoroutine(Wait(0.2f));
                NPCnameText.text = NPCname;
            }
            else if(!Waiting){
                ShopPanel.SetActive(false);
                PlayerGameObject.GetComponent<PlayersController>().enabled = true;
                StartCoroutine(Wait(0.2f));
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PausePanel.activeInHierarchy)
        {
            ShopPanel.SetActive(false);
        }
    }

    public IEnumerator Wait(float Sec)
    {
        Waiting = true;
        yield return new WaitForSeconds(Sec);
        Waiting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InRange = false;
        }
    }
}
