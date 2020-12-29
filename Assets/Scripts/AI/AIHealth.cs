using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int curHealth;
    public GameObject[] deathSpawns;

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        curHealth -= damageAmount;

        if(curHealth < 1)
        {
            print("DEATH");
            if(GetComponent<BossAttack>() != null)
            {
                GetComponent<BossAttack>().Die();
                return;
            }
            Die();
        }
    }

    void Die()
    {
        if (deathSpawns.Length > 0)
        {
            foreach (GameObject curDeathSpawnGO in deathSpawns)
            {
                GameObject spawnedDeathSpawn = Instantiate(curDeathSpawnGO);
                spawnedDeathSpawn.transform.position = transform.position;
            }
        }
        Destroy(gameObject);
    }

}