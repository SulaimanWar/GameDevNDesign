using UnityEngine;

public class AIProjectile : MonoBehaviour
{
    public AIProjectileData projectileData;
    float lifetime;
    bool firing = false;

    public void Setup()
    {
        lifetime = Time.time + 3f;
        firing = true;
    }

    private void Update()
    {
        transform.position += transform.up * projectileData.speed * Time.deltaTime;

        if (firing)
        {
            if (Time.time > lifetime)
            {
                Destroy(gameObject);
            }
        }
    }
}