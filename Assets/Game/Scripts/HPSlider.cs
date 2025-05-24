using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Transform _target;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (_target != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(
                _target.position + _offset);
        }
    }

    public void SetTarget(Transform target, int maxValue)
    {
        _target = target;
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    public void ChangeValue(int value)
    {
        _slider.value = value;
    }

    internal void DestroyObj(Enemy enemy)
    {
        enemy.OnDead -= DestroyObj;
        Destroy(gameObject);
    }
}

