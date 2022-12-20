using System;
using UnityEngine;


public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] float range;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] private float _rotationSpeed;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance) 
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        if (target == null) { return; }    
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        Vector3 directionToTarget = target.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(directionToTarget);
        Vector3 rotation = Quaternion.Lerp(weapon.rotation, lookAtRotation, Time.deltaTime*_rotationSpeed).eulerAngles;
        weapon.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
        
        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled= isActive;
    }
}
