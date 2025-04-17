using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;

    void Update()
    {
        //float moveForward = Input.GetAxis("Horizontal");
        //float moveSide = Input.GetAxis("Vertical");

        //Vector3.MoveTowards(transform.position,
        //    transform.forward * moveForward,
        //    _speed * Time.deltaTime);
    }
}
