using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Скрипт реализует плавное движение камеры вслед за target
public class CameraMovement : MonoBehaviour
{
    public float speed;
    public Transform targert;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targert.position+offset, speed * Time.deltaTime);
    }
}
