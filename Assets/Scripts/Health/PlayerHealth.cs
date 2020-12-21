using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxShield = 100f;
    float curHealth = 100f;
    float curShield = 100f;

    [SerializeField] Slider shieldSlider;
    [SerializeField] Slider healthSlider;

    void Die()
    {
        //DEATH CODE HERE
        //REPLACE THIS PLACEHOLDER CODE
        Destroy(gameObject);
    }



    //This is a public function to update our health
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

    //This is a public function to update our shield
    //Maybe by drinking potion or getting attacked
    public void ModifyShield(int modifyAmount)
    {
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


    void UpdateUI()
    {
        shieldSlider.value = curShield / maxShield;
        healthSlider.value = curHealth / maxHealth;
    }
}
