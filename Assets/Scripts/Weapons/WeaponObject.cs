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

    private void Update()
    {
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
}
