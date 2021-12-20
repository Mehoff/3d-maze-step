using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followable;
    private Vector3 offset;
    private Vector3 point;


    public float smoothSpeed = 0.125f;
    public Vector3 smoothCameraOffset;
    private float rotateSpeed;

    void Start()
    {
        rotateSpeed = 5f;
        offset = transform.position - followable.transform.position;
        point = followable.transform.position;
    }
    void FixedUpdate()
    {
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
        offset = camTurnAngle * offset;

        Vector3 newPos = followable.transform.position + offset;

        this.transform.position = Vector3.Slerp(transform.position, newPos, 0.125f);

        this.transform.LookAt(followable.transform);
    }
}