using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int maxHealth = 50;
    int curHealth;

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        curHealth -= damageAmount;

        if(curHealth < 1)
        {
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
        Destroy(gameObject);
    }

}