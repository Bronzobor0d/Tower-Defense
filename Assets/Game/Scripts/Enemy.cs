using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _hpSlider;
    [SerializeField] private int _maxHP;
    [SerializeField] private float _speed;
    private List<Transform> _wayPoints = new List<Transform>();
    private bool _isDead;
    private int _currentHP;
    private HPSlider _hpScript;

    public Canvas Canvas;

    public event Action<Enemy> OnDead;

    private void Start()
    {
        _currentHP = _maxHP;
        GameObject hpObj = Instantiate(_hpSlider, Canvas.transform);
        _hpScript = hpObj.GetComponent<HPSlider>();
        _hpScript.SetTarget(transform, _maxHP);
        OnDead += _hpScript.DestroyObj;
    }

    private void Dead()
    {
        _isDead = true;
        OnDead?.Invoke(this);
        Destroy(gameObject);
    }

    internal void SetWay(List<Transform> wayPoints)
    {
        _wayPoints = new List<Transform>(wayPoints);
    }

    void Update()
    {
        if (_wayPoints.Count > 0 && Vector3.Distance(
            transform.position, _wayPoints[0].position)
            > 0.3f)
        {
            transform.LookAt(_wayPoints[0].position);
            transform.position = Vector3.MoveTowards(
                transform.position,
                _wayPoints[0].position,
                _speed * Time.deltaTime);
        }
        else if (_wayPoints.Count > 0 && Vector3.Distance(
            transform.position, _wayPoints[0].position)
            <= 0.3f)
        {
            _wayPoints.RemoveAt(0);
            if (_wayPoints.Count == 0 && !_isDead)
                Dead();
        }

    }
}
