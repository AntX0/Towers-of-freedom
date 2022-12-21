using System;
using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField][Range(0, 50)] private int _poolSize;
    [SerializeField][Range(0.1f, 30f)] private float _spawnRate;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[_poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
            pool[i].SetActive(false);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                /*GetComponent<EnemyHealth>().IsDead= false;*/
                return;
            }
        }
    }
}
