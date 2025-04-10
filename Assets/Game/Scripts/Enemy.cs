using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private List<Transform> _wayPoints;

    internal void SetWay(List<Transform> wayPoints)
    {
        _wayPoints = wayPoints;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
