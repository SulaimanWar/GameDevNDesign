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
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}