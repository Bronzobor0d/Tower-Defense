using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private List<Transform> _wayPoints = new List<Transform>();

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
            if (_wayPoints.Count == 0)
                Destroy(gameObject);
        }

    }
}
