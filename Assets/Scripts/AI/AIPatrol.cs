using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    int patrolIndex;

    public Vector3 NextPoint()
    {
        patrolIndex++;
        if(patrolIndex >= patrolPoints.Length)
        {
            patrolIndex = 0;
        }

        return patrolPoints[patrolIndex].position;
    }
}