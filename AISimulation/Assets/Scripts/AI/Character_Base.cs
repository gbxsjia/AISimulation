using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    private Rigidbody rb;

    public float MoveSpeed;
    public float MoveAcceleration;
    public Vector3 LastMoveDirection;

    public float RotationSpeed;
    public Transform FocusTransform;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        LastMoveDirection = transform.forward;
    }
    public void Move(Vector3 Direction)
    {
        Direction.Normalize();
        if (Direction != Vector3.zero)
        {
            LastMoveDirection = Direction;
            if (!FocusTransform)
            {
                RotateTowards(transform.position + Direction);
            }          
        } 
        rb.velocity = Vector3.MoveTowards(rb.velocity, Direction * MoveSpeed, MoveAcceleration);
    }

    public void RotateTowards(Vector3 targetPos)
    {
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), RotationSpeed * Time.deltaTime);
    }
    private void Update()
    {
        if (FocusTransform)
        {
            RotateTowards(FocusTransform.position);
        }
    }
}
