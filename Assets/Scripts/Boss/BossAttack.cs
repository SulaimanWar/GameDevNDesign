using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform[] bulletSpawnPoints;
    public bool shooting;
    public float shootInterval = 0.75f;
    float nextShootTime;

    [Space(15)]

    public GameObject projectile;

    [Space(15)]

    public bool spiral;
    public Transform spawnGrp;
    public float rotateSpeed = 4f;

    private void Update()
    {
        if (shooting)
        {
            if(Time.time > nextShootTime)
            {
                nextShootTime = Time.time + shootInterval;
                Shoot();
            }

            if (spiral)
            {
                spawnGrp.transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime));
            }
        }
    }

    void Shoot()
    {
        foreach(Transform curSpawnPoint in bulletSpawnPoints)
        {
            Vector2 shootDir = (new Vector2(curSpawnPoint.position.x, curSpawnPoint.position.y) -
                new Vector2(transform.position.x, transform.position.y)).normalized;

            float targetX = curSpawnPoint.position.x - transform.position.x;
            float targetY = curSpawnPoint.position.y - transform.position.y;

            GameObject spawnedProjectile = Instantiate(projectile, curSpawnPoint);
            spawnedProjectile.transform.localPosition = Vector3.zero;
            float angle = Mathf.Atan2(targetY, targetX) * Mathf.Rad2Deg;
            spawnedProjectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
            spawnedProjectile.transform.parent = null;
        }
    }
}
