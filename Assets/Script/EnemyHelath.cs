using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHelath : MonoBehaviour
{
    [SerializeField] float maxHp = 0f;
    [SerializeField] float currentHP = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHp;
    }


void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHP--;
        if (currentHP < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
