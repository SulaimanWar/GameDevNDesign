﻿using UnityEngine;

public class Projectile : MonoBehaviour
{
    float lifeTime;
    float speed;
    int damage;

    public void SetProjectile(WeaponData weaponData)
    {
        lifeTime = Time.time + weaponData.projectileLifetime;
        speed = weaponData.projectileSpeed;
        damage = weaponData.damageAmount;
    }

    private void Update()
    {

        transform.position += transform.up * speed * Time.deltaTime;
        if(Time.time > lifeTime)
        {
            Destroy(gameObject);
        }



        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, transform.up);

        if(rayHit.collider == null)
        {
            return;
        }

        if ((new Vector3(rayHit.transform.position.x, rayHit.transform.position.y, 0f) - 
            new Vector3 (transform.position.x, transform.position.y, 0f)).magnitude < 1f)
        {
            switch (rayHit.collider.tag)
            {
                case "Enemy":
                    AIHealth aiHealth = rayHit.collider.GetComponent<AIHealth>();
                    aiHealth.Damage(damage);
                    Destroy(gameObject);
                    break;

                case "Destructible":
                    Destructible destructible = rayHit.collider.GetComponent<Destructible>();
                    destructible.TakeDamage(damage);
                    Destroy(gameObject);
                    break;
            }

        }

    }
}
