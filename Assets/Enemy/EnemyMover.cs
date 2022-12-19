using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] private float _enemySpeed = 1f;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath() 
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            var travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f) 
            {
                travelPercent += Time.deltaTime * _enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    } 
}
