﻿using System.Collections;
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

    enum Direction
    {
        LEFT, UP, RIGHT, DOWN
    }
    Direction dirEnum;
    Transform playerTransform;

    private Camera mainCamera;
    private GameObject reticle;

    private Vector3 direction;
    private Vector3 mousePosition;
    private Vector3 reticlePosition;
    public GameObject reticlePrefab;


    private void Start()
    {
        playerTransform = transform;

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

        #region RAYCAST

        GetMousePosition();
        MoveReticle();

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
    }
    private void MoveReticle()
    {
        reticle.transform.rotation = Quaternion.identity; //set the normal rotation
        reticle.transform.position = reticlePosition;
    }


}
