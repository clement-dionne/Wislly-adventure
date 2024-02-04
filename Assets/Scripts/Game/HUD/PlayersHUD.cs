using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersHUD : MonoBehaviour
{
    #region Unity Public
    public PlayerHealth Health;
    public DataManager SaveSystem;

    public Slider HealthBar;

    public Text Coins;
    public Text Damage;
    public Text Shield;
    public Text Level;
    public Text Pseudo;
    public Text HealthCount;

    public Item CoinsObject;
    public Item DamageObject; 
    public Item ShieldObject; 
    public Item LevelObject;
    #endregion

    // Update is called once per frame
    void Update()
    {
        Coins.text = "CO : " + CoinsObject.NumberOfObject.ToString();
        Damage.text = "ATQ : " + DamageObject.NumberOfObject.ToString();
        Shield.text = "DEF : " + ShieldObject.NumberOfObject.ToString();
        Level.text = "LVL : " + LevelObject.NumberOfObject.ToString();
        Pseudo.text = SaveSystem.PlayerName;
        HealthCount.text = "HP : " + Health.PlayerCurrentHealth.ToString();

        HealthBar.value = Health.PlayerCurrentHealth / Health.PlayerMaxHealth;
    }
}
