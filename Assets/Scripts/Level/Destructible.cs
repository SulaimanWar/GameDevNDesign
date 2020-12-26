using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject spawnableObject;
    public GameObject debrisPrefab;
    public int health = 50;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health < 0)
        {
            DestroyDestructible();
        }
    }

    void DestroyDestructible()
    {
        GameObject spawnedSpawnable = Instantiate(spawnableObject);
        spawnedSpawnable.transform.position = transform.position;

        GameObject spawnedDebris = Instantiate(debrisPrefab);
        spawnedDebris.transform.position = transform.position - transform.up;
        Destroy(gameObject);
    }
}
