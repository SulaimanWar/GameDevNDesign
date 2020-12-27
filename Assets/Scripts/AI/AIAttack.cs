using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public float range = 4f;
    [HideInInspector] public bool attacking;
    GameObject player;

    [Space(15)]

    public float attackInterval = 0.75f;
    float nextAttackTime;
    public GameObject projectilePrefab;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (attacking)
        {
            if(Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackInterval;
                Shoot();
            }

            Vector2 shootDir = (new Vector2(transform.position.x, transform.position.y) -
                new Vector2(player.transform.position.x, player.transform.position.y)).normalized;

            float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 270f));
        }
    }

    void Shoot()
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, transform);
        spawnedProjectile.transform.localPosition = Vector3.zero;
        spawnedProjectile.transform.localRotation = Quaternion.identity;
        spawnedProjectile.transform.parent = null;

        AIProjectile aiProjectile = spawnedProjectile.GetComponent<AIProjectile>();
        aiProjectile.Setup();
    }
}