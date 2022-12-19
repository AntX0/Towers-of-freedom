using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlacebale;
    [SerializeField] GameObject towerPrefab;

    private void OnMouseDown()
    {
        if (isPlacebale)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlacebale = false;
        }
    }
}
