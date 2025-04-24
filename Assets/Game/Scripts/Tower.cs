using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<Enemy> Enemies = new List<Enemy>();

    internal void RemoveEnemy(Enemy enemy)
    {
        if (Enemies.Contains(enemy))
            Enemies.Remove(enemy);
    }

    internal void SetEnemy(Enemy enemy)
    {
        if (!Enemies.Contains(enemy))
            Enemies.Add(enemy);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
