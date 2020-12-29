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
    GameObject playerGO;
    public float attackRange = 10f;

    [Space(15)]

    public DialogueData deathDialogue;
    public GameObject activeTargetGO;
    public GameObject[] deathSpawns;

    public float dist;

    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

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

        float distToPlayer = (playerGO.transform.position - transform.position).magnitude;
        dist = distToPlayer;
        if(distToPlayer < attackRange)
        {
            shooting = true;
        }
        else
        {
            shooting = false;
        }
    }

    void Shoot()
    {
        foreach(Transform curSpawnPoint in bulletSpawnPoints)
        {
            Vector2 shootDir = (new Vector2(curSpawnPoint.position.x, curSpawnPoint.position.y) -
                new Vector2(spawnGrp.position.x, spawnGrp.position.y)).normalized;

            float targetX = curSpawnPoint.position.x - spawnGrp.position.x;
            float targetY = curSpawnPoint.position.y - spawnGrp.position.y;

            GameObject spawnedProjectile = Instantiate(projectile, curSpawnPoint);
            spawnedProjectile.transform.localPosition = Vector3.zero;
            float angle = Mathf.Atan2(targetY, targetX) * Mathf.Rad2Deg;
            spawnedProjectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
            spawnedProjectile.transform.parent = null;

            AIProjectile aiProjectile = spawnedProjectile.GetComponent<AIProjectile>();
            aiProjectile.Setup();
        }
    }

    public void Die()
    {
        if(deathDialogue != null)
        {
            GameObject newDialogue = new GameObject("BossDeathDialogue");
            if(activeTargetGO != null)
            {
                ActionObject actionObj = newDialogue.AddComponent<ActionObject>();
                actionObj.activeActionTarget = activeTargetGO;
            }
            DialogueObject dialogueObj = newDialogue.AddComponent<DialogueObject>();
            dialogueObj.dialogueData = deathDialogue;
            dialogueObj.StartConversation();
        }

        if(deathSpawns.Length > 0)
        {
            foreach(GameObject curDeathSpawnGO in deathSpawns)
            {
                GameObject spawnedDeathSpawn = Instantiate(curDeathSpawnGO);
                spawnedDeathSpawn.transform.position = transform.position;
            }
        }
        
        Destroy(gameObject);
    }
}
