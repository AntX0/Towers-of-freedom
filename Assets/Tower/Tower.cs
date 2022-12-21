using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _cost = 50;

    public bool CreateTower(Tower tower, Vector3 positon)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) { return false; }

        if (bank.CurrentBalance >= _cost)
        {
            Instantiate(tower.gameObject, positon, Quaternion.identity);
            bank.Withdraw(_cost);
            return true;
        } 
        
        return false;
    }
}
