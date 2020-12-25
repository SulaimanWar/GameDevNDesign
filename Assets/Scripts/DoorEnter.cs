using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorEnter : MonoBehaviour

{
    public Transform TargetDoor;
    public float minX, maxX, minY, maxY;

    private bool isDoor;
    private Transform playerTransform;

    

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnterDoor();
        }
    }
    void EnterDoor()
    {
        if (isDoor)
        {
            playerTransform.position = TargetDoor.position;
        }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")
            &&other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isDoor = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isDoor = false;
        }
    }
  
}