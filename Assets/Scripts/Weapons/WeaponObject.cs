using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public WeaponData[] weaponDatas;
    WeaponData curWeaponData;

    KeyCode weaponAKeycode = KeyCode.Alpha1;
    KeyCode weaponBKeycode = KeyCode.Alpha2;
    KeyCode weaponCKeycode = KeyCode.Alpha3;
    KeyCode weaponDKeycode = KeyCode.Alpha4;

    /*
    enum Direction
    {
        LEFT, UP, RIGHT, DOWN
    }
    Direction dirEnum;
    Transform playerTransform;
    */

    private Camera mainCamera;
    private GameObject reticle;

    private Vector3 direction;
    private Vector3 mousePosition;
    private Vector3 reticlePosition;
    public GameObject reticlePrefab;


    private void Start()
    {
       // playerTransform = transform;

        Cursor.visible = false;
        mainCamera = Camera.main;
        reticle = Instantiate(reticlePrefab);
    }

    private void Update()
    {
        #region INPUT
        if (Input.GetKeyDown(weaponAKeycode))
        {
            SetData(0);
        }

        if (Input.GetKeyDown(weaponBKeycode))
        {
            SetData(1);
        }

        if (Input.GetKeyDown(weaponCKeycode))
        {
            SetData(2);
        }

        if (Input.GetKeyDown(weaponDKeycode))
        {
            SetData(3);
        }
        #endregion

        #region Reticle

        GetMousePosition();
        MoveReticle();

        #endregion

        #region RAYCAST
        Vector2 rayDir = (new Vector2(mousePosition.x, mousePosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, rayDir * 2f);

        Debug.DrawRay(transform.position, rayDir * 2f);
        #endregion
    }

    void SetData(int weaponIndex)
    {
        if(weaponIndex > weaponDatas.Length - 1)
        {
            return;
        }
        curWeaponData = weaponDatas[weaponIndex];

        spriteRenderer.sprite = curWeaponData.weaponSprite;
    }


    private void GetMousePosition()
    {
        // Get Mouse Position
        mousePosition = Input.mousePosition;
        mousePosition.z = 5f;  // We set this value to ensure the camera always stays infront to view everything in game

        // Get World space position
        direction = mainCamera.ScreenToWorldPoint(mousePosition);
        direction.z = transform.position.z;
        reticlePosition = direction;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - objectPos.x;
        mousePosition.y = mousePosition.y - objectPos.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void MoveReticle()
    {
        reticle.transform.rotation = Quaternion.identity; //set the normal rotation
        reticle.transform.position = reticlePosition;
    }



}
