using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocation : MonoBehaviour
{
    [SerializeField] Transform Weapon;

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        Weapon.LookAt(target);
    }
}
