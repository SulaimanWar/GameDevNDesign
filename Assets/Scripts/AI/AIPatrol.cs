using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    int patrolIndex;
    public bool randomise;

    public Vector3 NextPoint()
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

        return patrolPoints[patrolIndex].position;
    }
}