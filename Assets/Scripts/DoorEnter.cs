using UnityEngine;
using UnityEngine.SceneManagement;



public class DoorEnter : MonoBehaviour

{
    public Transform TargetDoor;
    public float minX, maxX, minY, maxY;

    private bool isDoor;
    private Transform playerTransform;

    [Space(20)]

    public string levelToLoad;
    public bool loadLevel;
    CameraController camControl;



    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camControl = FindObjectOfType<CameraController>();
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
        if (isDoor && TargetDoor != null)
        {
            playerTransform.position = TargetDoor.position;
            camControl.ChangeRoom(minX, maxX, minY, maxY);
        }

        AIChase[] aiChases = FindObjectsOfType<AIChase>();
        foreach(AIChase aiChase in aiChases)
        {
            aiChase.ChaseEnterDoor();
        }
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if(other.gameObject.CompareTag("Player")
            &&other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (loadLevel)
            {
                SceneManager.LoadScene(levelToLoad);
            }
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