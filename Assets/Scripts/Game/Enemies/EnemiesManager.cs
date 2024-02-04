using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    #region Unity Public
    public Item DamageObject;
    public Slider HealthBar;

    public float Health = 1;
    public float Damage = 1;
    #endregion

    private float MaxHealth;

    void Start()
    {
        MaxHealth = Health;
    }

    void Update()
    {
        HealthBar.value = Health/MaxHealth;
        if (Health <= 0) Destroy(gameObject.transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerATT")
        {
            Health -= DamageObject.NumberOfObject;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().PlayerCurrentHealth -= Damage;
        }
    }
}
