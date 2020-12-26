using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float chaseSpeed = 8f;
    GameObject player;
    bool chasing;
    float distToPlayer;

    AIPatrol aiPatrol;
    AIAttack aiAttack;
    public bool inRange;
    public bool moving;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        aiPatrol = GetComponent<AIPatrol>();
        aiAttack = GetComponentInChildren<AIAttack>();
    }

    void Update()
    {
        if (chasing)
        {
            if (!inRange)
            {
                Vector2 rayDir = (new Vector2(player.transform.position.x, player.transform.position.y) -
                new Vector2(transform.position.x, transform.position.y)).normalized;
                transform.position += new Vector3(rayDir.x, rayDir.y, 0f) * chaseSpeed * Time.deltaTime;
            }

            distToPlayer = (new Vector2(player.transform.position.x, player.transform.position.y) -
                new Vector2(transform.position.x, transform.position.y)).magnitude;

            if(distToPlayer < aiAttack.range)
            {
                aiAttack.attacking = true;
                inRange = true;
            }
            else
            {
                aiAttack.attacking = false;
                inRange = false;
            }
        }
    }

    public void Chase()
    {
        chasing = true;
        aiPatrol.enabled = false;
    }
}
