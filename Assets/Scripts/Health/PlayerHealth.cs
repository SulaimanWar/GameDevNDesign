using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float maxShield;
    float curHealth = 100f;
    float curShield = 100f;



    
    //It also makes sure we do not exceed the minimum and maximum health
    void CheckHealth()
    {

    }

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

        if(curHealth < 1)
        {
            //This just checks to see if we should be dead
        }
    }

    //This is a public function to update our shield
    //Maybe by drinking potion or getting attacked
    public void ModifyShield(int modifyAmount)
    {
        curShield += modifyAmount;
    }
}
