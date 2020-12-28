using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    enum Direction
    {
        LEFT, UP, RIGHT, DOWN
    }
    Direction dirEnum;
    Transform playerTransform;


    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h > 0.5f)
        {
            dirEnum = Direction.RIGHT;
        }
        else if (h < -0.5f)
        {
            dirEnum = Direction.LEFT;
        }

        if (v > 0.5f)
        {
            dirEnum = Direction.UP;
        }
        else if (v < -0.5f)
        {
            dirEnum = Direction.DOWN;
        }

        Vector2 rayDir = GetDirection();

        RaycastHit2D rayHit = Physics2D.Raycast(playerTransform.position, rayDir * 2f);
        if (rayHit.collider == null)
        {
            return;
        }
        if (rayHit.collider.tag == "Pickup")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Pickup pickup = rayHit.collider.GetComponent<Pickup>();

                Debug.DrawLine(transform.position, rayHit.point, Color.green, 2f);

                SetKey(pickup);
                Destroy(pickup.gameObject);
            }
        }
    }

    Vector2 GetDirection()
    {
        Vector2 rayDir = new Vector2();

        switch (dirEnum)
        {
            case Direction.LEFT:
                rayDir = -transform.right;
                break;

            case Direction.UP:
                rayDir = transform.up;
                break;

            case Direction.RIGHT:
                rayDir = transform.right;
                break;

            case Direction.DOWN:
                rayDir = -transform.up;
                break;
        }

        return rayDir;
    }

    void SetKey(Pickup pickup)
    {
        switch (pickup.keyType)
        {
            case Pickup.KeyType.FLOAT:
                PlayerPrefs.SetFloat(pickup.keyName, pickup.floatKey);
                break;

            case Pickup.KeyType.INT:
                PlayerPrefs.SetInt(pickup.keyName, pickup.intKey);
                break;

            case Pickup.KeyType.STRING:
                PlayerPrefs.SetString(pickup.keyName, pickup.stringKey);
                break;
        }
    }
}
