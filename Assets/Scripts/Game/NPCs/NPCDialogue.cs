using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    #region Unity Public
    [TextArea(2, 10)]
    public string[] Dialogue;

    public GameObject BoiteDeDialogue;
    public Text TextDialogue;
    public bool InRange;
    public float DialogueSpeed = 0.05f;

    public GameObject PlayerGameObject;

    public Animator NPCanimation;
    #endregion

    #region VisualStudios Private
    private bool Waiting;
    private int NbDeMess = 0;
    private bool EndDia;
    #endregion

    // message limit / box : 210

    public void Start()
    {
        BoiteDeDialogue.SetActive(false);
        InRange = false;
        Waiting = false;
        EndDia = true;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && EndDia)
        {
            if (!BoiteDeDialogue.activeInHierarchy && InRange && !Waiting)
            {
                BoiteDeDialogue.SetActive(true);
                PlayerGameObject.GetComponent<PlayersController>().enabled = false;
                NbDeMess = Dialogue.Length;
                DialogueManager();
                StartCoroutine(Wait(0.2f));
            }
            else if (!Waiting)
            {
                if (NbDeMess != 0)
                {
                    NbDeMess -= 1;
                    DialogueManager();
                    StartCoroutine(Wait(0.2f));
                }
                else {
                    BoiteDeDialogue.SetActive(false);
                    PlayerGameObject.GetComponent<PlayersController>().enabled = true;
                    StartCoroutine(Wait(0.2f));
                }
            }
        }
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

    public void DialogueManager()
    {
        int MessageIndex = NbDeMess;
        StartCoroutine(Speak(DialogueSpeed, Dialogue[MessageIndex - 1]));
    }

    public IEnumerator Wait(float Sec)
    {
        Waiting = true;
        yield return new WaitForSeconds(Sec);
        Waiting = false;
    }

    public IEnumerator Speak(float Sec, string Message)
    {
        NPCanimation.SetBool("Speak", true);
        EndDia = false;
        TextDialogue.text = "";
        foreach (char str in Message)
        {
            yield return new WaitForSeconds(Sec);
            TextDialogue.text += str.ToString();
        }
        NPCanimation.SetBool("Speak", false);
        EndDia = true;
    }
}