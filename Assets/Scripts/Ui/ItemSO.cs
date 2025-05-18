using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange;
    public int amountToChangeStat;
    public GameObject projectilePrefab;
    public Sprite projectileSprite; 

    public bool UseItem()
    {
        return true;
    }

    public enum StatToChange
    {
        none,
        health,
        mana,
        stamina
    }
}
