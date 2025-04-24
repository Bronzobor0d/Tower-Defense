using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    void Update()
    {
        float moveForward = Input.GetAxisRaw("Horizontal");
        float moveSide = Input.GetAxisRaw("Vertical");
        if (moveForward != 0 || moveSide != 0)
        {
            float y = transform.position.y;
            Vector3 movement = new Vector3(moveForward, 0, moveSide);
            transform.Translate(movement * Time.deltaTime * _speedMove);
            transform.position = new Vector3(transform.position.x,
                y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, _speedMove *
                Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= new Vector3(0, _speedMove *
                Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, _speedRotate * Time.deltaTime, 0,
                Space.World);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -_speedRotate * Time.deltaTime, 0,
                Space.World);
        }
    }
}
