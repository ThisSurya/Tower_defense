using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHelath : MonoBehaviour
{
    [SerializeField] float maxHp = 0f;
    [SerializeField] float currentHP = 0f;

    Enemy enemy;
    // Start is called before the first frame update

    void OnEnable()
    {
        currentHP = maxHp;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
        
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
            enemy.RewardGold();
            gameObject.SetActive(false);
        }
    }
}
