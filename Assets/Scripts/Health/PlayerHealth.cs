using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxShield = 100;
    int curHealth = 100;
    int curShield = 100;

    [SerializeField] Slider shieldSlider;
    [SerializeField] Slider healthSlider;


    private void Start()
    {
        UpdateUI();
    }


    void Die()
    {
        //DEATH CODE HERE
        //REPLACE THIS PLACEHOLDER CODE
        Destroy(gameObject);
    }



    //This is a public function to update our health amount
    //Maybe by drinking potion or getting attacked
    public void ModifyHealth(int modifyAmount)
    {
        curHealth += modifyAmount;

        //This just checks to see if we should be dead
        if (curHealth < 1)
        {
            Die();
        }

        //Make sure we do not exceed the maximum health
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        //Update UI
        UpdateUI();
    }

    //This is a public function to update our shield amount
    //Maybe by drinking potion or getting attacked
    public void ModifyShield(int modifyAmount, bool shieldOnly)
    {
        //If damage received is more than the shield amount, transfer that damage into health
        if(modifyAmount > curShield && !shieldOnly)
        {
            ModifyHealth(curShield - modifyAmount);
        }

        curShield += modifyAmount;

        //Make sure we do not exceed the minimum and maximum shield
        if (curShield <= 0f)
        {
            curShield = 0;
        }

        if (curShield > maxShield)
        {
            curShield = maxShield;
        }

        //Update UI
        UpdateUI();
    }

    //Update UI
    void UpdateUI()
    {
        shieldSlider.value = (float)curShield / maxShield;
        healthSlider.value = (float)curHealth / maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "HealthPickup":
                HealthPickup healthPickup = col.GetComponent<HealthPickup>();

                ModifyHealth(healthPickup.healthBoost);
                ModifyShield(healthPickup.shieldBoost, true);

                Destroy(col.gameObject);
                break;

            case "EnemyProjectile":
                AIProjectile aiProjectile = col.GetComponent<AIProjectile>();
                ModifyShield(-aiProjectile.projectileData.damage, false);

                Destroy(aiProjectile.gameObject);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Trap":
                Trap trap = col.GetComponent<Trap>();

                if (trap.TrapCheck())
                {
                    if(Time.time > trap.nextDamageTime)
                    {
                        ModifyShield(-trap.damageAmount, false);
                        trap.damagedPlayer = true;

                        trap.nextDamageTime = Time.time + trap.damageInterval;
                    }
                }
                break;
        }
    }
}
