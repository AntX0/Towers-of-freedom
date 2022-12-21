using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlacebale;
    public bool IsPlacebale => isPlacebale;

    [SerializeField] Tower towerPrefab;
   

    private void OnMouseDown()
    {
        if (isPlacebale)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlacebale = !isPlaced;
        }
    }
}
