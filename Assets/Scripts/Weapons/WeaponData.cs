using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapon", fileName = "weapon_")]
public class WeaponData : ScriptableObject
{
    public Sprite weaponSprite;
    public string weaponPrefKey;

    [Space(10)]

    public int damageAmount;

    [Space(5)]

    public bool ranged;
    public GameObject projectileGO;
    public float projectileLifetime;
    public float projectileSpeed;
    public float bulletSpawnDist = 0.25f;
}
