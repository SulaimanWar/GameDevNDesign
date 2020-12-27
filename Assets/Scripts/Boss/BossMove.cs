using UnityEngine;

public class BossMove : MonoBehaviour
{
    public bool moving = true;
    public Transform[] movePoint;
    int curIndex;
    public bool randomiseMovePoints;

    [Space(15)]

    public float speed = 5f;

    private void Update()
    {
        if (moving)
        {
            Vector2 curPoint = new Vector2(movePoint[curIndex].position.x, movePoint[curIndex].position.y);
            Vector2 moveDir = (curPoint - new Vector2(transform.position.x, transform.position.y));

            transform.position += new Vector3(moveDir.x, moveDir.y, 0f) * speed * Time.deltaTime;

            float distToPoint = (new Vector3(curPoint.x, curPoint.y, 0f) -
                new Vector3(transform.position.x, transform.position.y, 0f)).magnitude;

            if(distToPoint < 2f)
            {
                NextPoint();
            }
        }
    }

    void NextPoint()
    {
        curIndex++;

        if (randomiseMovePoints)
        {
            curIndex = Random.Range(0, movePoint.Length);
        }

        if(curIndex >= movePoint.Length)
        {
            curIndex = 0;
        }
    }
}