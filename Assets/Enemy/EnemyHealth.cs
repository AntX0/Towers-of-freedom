using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Add amount to maxHitPoint when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    [SerializeField] bool isDead;
    public bool IsDead => isDead;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
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
            maxHitPoints += difficultyRamp;
        }
    }

    private void KillEnemy()
    {
      /*  if (isDead) { return; }*/
        GetComponent<Animator>().SetTrigger("Die");
        gameObject.SetActive(false);
        enemy.RewardGold();
       /* isDead = true;*/
    }
}
