using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    Vector2 patrolPos;
    int patrolIndex;
    public bool randomise;
    public float speed = 8f;

    private void Start()
    {
        if(patrolPoints.Length > 0)
        {
            patrolPos = new Vector2(patrolPoints[0].transform.position.x, patrolPoints[0].transform.position.y);
        }
    }

    private void Update()
    {
        Vector2 moveDir = (patrolPos - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.position += new Vector3(moveDir.x, moveDir.y, 0f) * (speed * Time.deltaTime);

        if((patrolPos - new Vector2(transform.position.x, transform.position.y)).magnitude < 0.5f)
        {
            NextPoint();
        }
    }

    public Vector2 NextPoint()
    {
        if (randomise)
        {
            patrolIndex = Random.Range(0, patrolPoints.Length - 1);
        }
        else
        {
            patrolIndex++;
        }

        if(patrolIndex >= patrolPoints.Length)
        {
            patrolIndex = 0;
        }

        patrolPos = new Vector2(patrolPoints[patrolIndex].transform.position.x, patrolPoints[patrolIndex].transform.position.y);

        return patrolPos;
    }
}