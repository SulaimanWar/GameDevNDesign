using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Projectile", fileName = "data_enemy_projectile_")]
public class AIProjectileData : ScriptableObject
{
    public float speed = 10f;
    public int damage = 10;
}
