using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _reloadTime;

    public Enemy Target;
    public List<Enemy> Enemies = new List<Enemy>();

    private bool _isShoot;

    internal void RemoveEnemy(Enemy enemy)
    {
        if (Enemies.Contains(enemy))
            Enemies.Remove(enemy);
        if (enemy == Target)
        {
            Target.OnDead -= RemoveEnemy;
            Target = null;
            SetNewTarget();
        }
    }

    private void SetNewTarget()
    {
        if (Enemies.Count > 0)
        {
            Target = Enemies.Last();
            Target.OnDead += RemoveEnemy;
        }
    }

    internal void SetEnemy(Enemy enemy)
    {
        if (!Enemies.Contains(enemy))
            Enemies.Add(enemy);
        if (Target == null)
            SetNewTarget();
    }

    void Update()
    {
        if (Target != null && !_isShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _isShoot = true;
        yield return new WaitForSeconds(_reloadTime);
        if (Target != null)
        {
            GameObject bulletObj = Instantiate(_bullet, _bulletSpawn.position,
           Quaternion.identity);
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.SetTarget(Target.transform);
            Target.OnDead += bullet.DestroyBullet;
        }
        _isShoot = false;
    }
}
