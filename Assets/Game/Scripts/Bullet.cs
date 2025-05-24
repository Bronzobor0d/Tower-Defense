using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    void Update()
    {
        if (_target != null)
        {
            transform.LookAt(_target.position);
            transform.position = Vector3.MoveTowards(
                transform.position,
                _target.position,
                _speed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy) 
            && _target == enemy.transform)
        {
            DestroyBullet(enemy);
        }
    }

    internal void DestroyBullet(Enemy enemy)
    {
        enemy.OnDead -= DestroyBullet;
        Destroy(gameObject);
    }
}
