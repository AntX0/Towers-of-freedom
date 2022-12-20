using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    [SerializeField] bool isDead;
    public bool IsDead => isDead;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ApplyDamage();
    }

    private void ApplyDamage()
    {
        GetComponent<Animator>().SetTrigger("Take Damage");
        currentHitPoints -= 1;

        if (currentHitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        if (IsDead) { return; }
        GetComponent<Animator>().SetTrigger("Die");
        gameObject.SetActive(false);
        isDead = true;
    }
}
