using UnityEngine;

public class Trap : MonoBehaviour
{

    public int damageAmount = 10;

    [Space(10)]

    [Tooltip("How long the trap stays up")]
    public float trapLengthInSeconds = 3f;
    float nextTrapTime;
    public float damageInterval = 1f;
    [HideInInspector] public float nextDamageTime;
    bool trapEnabled;
    [HideInInspector] public bool damagedPlayer;

    public SpriteRenderer[] spriteRenderers;

    private void FixedUpdate()
    {
        if(Time.time > nextTrapTime)
        {
            nextTrapTime = Time.time + trapLengthInSeconds;
            trapEnabled = !trapEnabled;
            damagedPlayer = false;

            foreach(SpriteRenderer spriteRend in spriteRenderers)
            {
                spriteRend.enabled = trapEnabled;
            }
        }
    }

    public bool TrapCheck()
    {
        return trapEnabled;
    }

}
