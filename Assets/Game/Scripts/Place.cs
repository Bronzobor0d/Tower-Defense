using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public bool IsZanyato;

    private Tower _tower;

    internal void SetTower(Tower tower)
    {
        IsZanyato = true;
        _tower = tower;
    }
}
