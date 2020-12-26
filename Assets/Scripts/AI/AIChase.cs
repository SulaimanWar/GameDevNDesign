using UnityEngine;

public class AIChase : MonoBehaviour
{
    public float chaseSpeed = 8f;
    GameObject player;
    bool chasing;
    float distToPlayer;

    AIPatrol aiPatrol;
    AIAttack aiAttack;
    bool inRange;
    bool moving;

    Vector3 oriScale;

    private void Start()
    {
        oriScale = transform.localScale;
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
                Vector2 moveDir = (new Vector2(player.transform.position.x, player.transform.position.y) -
                new Vector2(transform.position.x, transform.position.y)).normalized;
                transform.position += new Vector3(moveDir.x, moveDir.y, 0f) * chaseSpeed * Time.deltaTime;

                if (moveDir.x > 0)
                {
                    transform.localScale = oriScale;
                }
                else
                {
                    transform.localScale = new Vector3(-oriScale.x, oriScale.y, oriScale.z);
                }
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
