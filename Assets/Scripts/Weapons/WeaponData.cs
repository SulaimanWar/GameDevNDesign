using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapon", fileName = "weapon_")]
public class WeaponData : ScriptableObject
{
    public Sprite weaponSprite;

    [Space(10)]

    public int damageAmount;

    [Space(5)]

    public bool ranged;
    public GameObject projectileGO;
    public float projectileLifetime;
    public float projectileSpeed;
}
