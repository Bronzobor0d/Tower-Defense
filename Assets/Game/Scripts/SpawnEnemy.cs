using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<Transform> _wayPoints 
        = new List<Transform>();
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _startSpawn;
    [SerializeField] private float _intervalSpawn;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyNow), _startSpawn,
            _intervalSpawn);
    }

    private void SpawnEnemyNow()
    {
        GameObject enemy = Instantiate(_enemy,
            _spawn.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().SetWay(_wayPoints);
    }
}
