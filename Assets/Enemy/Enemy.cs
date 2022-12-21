using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _goldReward;
    [SerializeField] private int _goldPenalty;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank == null) { return; }
        bank.Deposit(_goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(_goldPenalty);
    }
}
