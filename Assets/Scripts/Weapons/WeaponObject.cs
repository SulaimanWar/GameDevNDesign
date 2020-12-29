using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    GameObject projectileBase;

    public WeaponData[] weaponDatas;
    WeaponData curWeaponData;

    KeyCode weaponAKeycode = KeyCode.Alpha1;
    KeyCode weaponBKeycode = KeyCode.Alpha2;
    KeyCode weaponCKeycode = KeyCode.Alpha3;
    KeyCode weaponDKeycode = KeyCode.Alpha4;

    private Camera mainCamera;
    private GameObject reticle;

    private Vector3 direction;
    private Vector3 mousePosition = Vector3.zero;
    private Vector3 reticlePosition;
    public GameObject reticlePrefab;
    Vector2 rayDir;


    private void Start()
    {
       // playerTransform = transform;

        Cursor.visible = false;
        mainCamera = Camera.main;
        reticle = Instantiate(reticlePrefab);
        SetData(0);
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
        rayDir = (new Vector2(mousePosition.x, mousePosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            if (curWeaponData.ranged)
            {
                Shoot();
            }
            else
            {
                Melee();
            }
        }
            #endregion
    }



    void SetData(int weaponIndex)
    {
        if(weaponIndex != 0)
        {
            if(PlayerPrefs.GetInt(weaponDatas[weaponIndex].weaponPrefKey) != 1)
            {
                return;
            }
        }

        if(weaponIndex > weaponDatas.Length - 1)
        {
            return;
        }
        curWeaponData = weaponDatas[weaponIndex];

        spriteRenderer.sprite = curWeaponData.weaponSprite;
        projectileBase = curWeaponData.projectileGO;
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

    void Melee()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, rayDir * 5f);
        Debug.DrawRay(transform.position, rayDir * 5f, Color.red, 2f);
        if(rayHit.collider.tag == "Enemy")
        {
            AIHealth aiHealth = rayHit.collider.GetComponent<AIHealth>();
            aiHealth.Damage(curWeaponData.damageAmount);
        }

        if (rayHit.collider.tag == "Destructible")
        {
            Debug.Log(rayHit.collider.gameObject.name);
            Destructible destructible = rayHit.collider.GetComponent<Destructible>();
            destructible.TakeDamage(curWeaponData.damageAmount);
        }
    }

    void Shoot()
    {
        GameObject spawnedProjectile = Instantiate(projectileBase, transform);
        spawnedProjectile.transform.localPosition = Vector3.zero;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        spawnedProjectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        spawnedProjectile.transform.parent = null;
        Projectile projectile = spawnedProjectile.GetComponent<Projectile>();

        projectile.SetProjectile(curWeaponData);
    }
}