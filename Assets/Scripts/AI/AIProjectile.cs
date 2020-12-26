using UnityEngine;

public class AIProjectile : MonoBehaviour
{
    public AIProjectileData projectileData;
    float lifetime;

    public void Setup()
    {
        lifetime = Time.time + 4f;
    }

    private void Update()
    {
        transform.position += transform.up * projectileData.speed * Time.deltaTime;
        RaycastHit2D rayHit = 
    }
}