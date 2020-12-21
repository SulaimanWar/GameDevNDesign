using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapon", fileName = "weapon_")]
public class WeaponData : ScriptableObject
{
    public Sprite weaponSprite;

    [Space(10)]

    public float damageAmount;

    [Space(5)]

    public bool ranged;
    public Sprite projectileSprite;
    public float rangeAmount;
}
