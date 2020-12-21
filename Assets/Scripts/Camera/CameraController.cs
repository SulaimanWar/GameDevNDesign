using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private Transform target;

    public float Speed;
    [SerializeField] private float smoothSpeed;
    public float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), smoothSpeed = Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY),
                                         transform.position.z);
    }

    public void ChangeRoom(float NewminX, float NewmaxX, float NewminY, float NewmaxY)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Speed * Time.deltaTime);
        minX = NewminX;
        minY = NewminY;
        maxX = NewmaxX;
        maxY = NewmaxY;
    }
}
