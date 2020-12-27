using UnityEngine;

public class AIProjectile : MonoBehaviour
{
    public AIProjectileData projectileData;
    float lifetime;

    private void Start()
    {
        lifetime = Time.time + 4f;
    }

    private void Update()
    {
        transform.position += transform.up * projectileData.speed * Time.deltaTime;
        if(Time.time > lifetime)
        {
            Destroy(gameObject);
        }
    }
}