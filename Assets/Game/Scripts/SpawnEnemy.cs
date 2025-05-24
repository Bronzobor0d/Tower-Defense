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
    [SerializeField] private Canvas _canvas;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemyNow), _startSpawn,
            _intervalSpawn);
    }

    private void SpawnEnemyNow()
    {
        GameObject enemy = Instantiate(_enemy,
            _spawn.position, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.SetWay(_wayPoints);
        enemyScript.Canvas = _canvas;
    }
}
