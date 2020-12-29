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
        if(spawnableObject != null)
        {
            GameObject spawnedSpawnable = Instantiate(spawnableObject);
            spawnedSpawnable.transform.position = transform.position;
        }

        if (debrisPrefab != null)
        {
            GameObject spawnedDebris = Instantiate(debrisPrefab);
            spawnedDebris.transform.position = transform.position - transform.up;
        }
        
        Destroy(gameObject);
    }
}
