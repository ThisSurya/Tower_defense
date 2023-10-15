using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetLocation : MonoBehaviour
{
    // The tower
    [SerializeField] Transform Weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectileParticle;

    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindNearestEnemy();
        AimWeapon();
    }

    void FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    // Target the enemy
    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        Weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool IsActive)
    {
        var emission = projectileParticle.emission;
        emission.enabled = IsActive;
    }
}
