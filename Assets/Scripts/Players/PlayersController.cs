using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    #region Unity Public
    public Animator PlayerAnimator;
    public float speed;
    public SpriteRenderer PlayerGraphics;

    public GameObject Swoosh_D;
    public GameObject Swoosh_G;
    public GameObject Swoosh_Up;
    public GameObject Swoosh_Down;

    public GameObject FightPanel;
    #endregion

    private bool CanSwoosh = true;

    public void Start()
    {
        Swoosh_D.SetActive(false);
        Swoosh_G.SetActive(false);
        Swoosh_Up.SetActive(false);
        Swoosh_Down.SetActive(false);
        FightPanel.SetActive(false);
    }

    private void Update()
    {

        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.Q))
        {
            dir.x = -1;
            PlayerAnimator.SetFloat("DirectionX", -1);
            PlayerAnimator.SetFloat("DirectionY", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            PlayerAnimator.SetFloat("DirectionX", 1);
            PlayerAnimator.SetFloat("DirectionY", 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            dir.y = 1;
            PlayerAnimator.SetFloat("DirectionX", 0);
            PlayerAnimator.SetFloat("DirectionY", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            PlayerAnimator.SetFloat("DirectionX", 0);
            PlayerAnimator.SetFloat("DirectionY", -1);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!FightPanel.activeInHierarchy) FightPanel.SetActive(true);
            else FightPanel.SetActive(false);
        }

        PlayerAnimator.SetFloat("X", dir.x);
        PlayerAnimator.SetFloat("Y", dir.y);
        
        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = speed * dir * Time.deltaTime;
    }

    public void ButtonSwoosh(GameObject swoosh_Obj)
    {
        if (CanSwoosh) StartCoroutine(Swoosh(0.25f, swoosh_Obj));
    }

    public IEnumerator Swoosh(float time, GameObject swoosh_Obj)
    {
        CanSwoosh = false;
        swoosh_Obj.SetActive(true);
        Swoosh_D.transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z);
        Swoosh_G.transform.position = new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z);
        Swoosh_Up.transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
        Swoosh_Down.transform.position = new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z);
        yield return new WaitForSeconds(time);
        swoosh_Obj.SetActive(false);
        CanSwoosh = true;
    }
}