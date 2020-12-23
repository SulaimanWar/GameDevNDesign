using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueSystem : MonoBehaviour
{
    enum Direction
    {
        LEFT, UP, RIGHT, DOWN
    }
    Direction dirEnum;
    Transform playerTransform;

    Clue clue;
    bool clueMode;

    private void Start()
    {
        playerTransform = transform;
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
        if (rayHit.collider.tag == "Clue")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                clue = rayHit.collider.GetComponent<Clue>();
                clue.ActivateClue();
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
}
