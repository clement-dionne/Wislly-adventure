using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Unity Public
    public float PlayerMaxHealth = 100;
    public float PlayerCurrentHealth = 0;
    #endregion

    public void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {

            PlayerCurrentHealth -= 5;
        }

        if (Input.GetKey(KeyCode.L))
        {
            PlayerCurrentHealth += 5;
        }

        if (PlayerCurrentHealth <= 0)
        {
            PlayerCurrentHealth = 0;
        }
    }
}
