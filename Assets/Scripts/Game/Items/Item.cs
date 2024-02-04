using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/New Item", order = 1)]
public class Item : ScriptableObject
{
    public string ItemName = "NoName";
    public int NumberOfObject;
}
