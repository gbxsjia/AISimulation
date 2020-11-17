using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MovableObject
{

    public float MaxMotor;
    public float MaxSteering;
    public float MaxBrake;

    private float SteeringAngle;
    private float Motor;

    public float TargetSpeed;
    private bool isBraking;

    private RayTraceResult FrontRayResult=new RayTraceResult();
    [SerializeField]
    private Transform frontTracePosition;

    public void SetMotor(float percent)
    {
        if (percent > 0)
        {
            Motor=MaxMotor*percent;
        }
        else
        {
            Motor = MaxBrake * percent;
        }
    }
    public void SetSteering(float steering)
    {
        SteeringAngle = Mathf.Clamp(steering, -1, 1);
    }

    public void SetTargetSpeed(float targetSpeed)
    {
        TargetSpeed = targetSpeed;        
    }

    void FixedUpdate()
    {
        FrontRayTrace();
        //float h = -Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        Vector3 currentVelocity = rb.velocity;
        float currentSpeed = currentVelocity.magnitude;
        if (currentSpeed < TargetSpeed )
        {
            if (FrontRayResult.isHit)
            {
                SetMotor(-1);
                isBraking = true;
            }
            else
            {
                SetMotor(1);
                isBraking = false;
            }           
        }
        else
        {
            SetMotor(-1);
            isBraking = true;
        }



        Vector2 speed = transform.up * Motor;
        rb.AddForce(speed);
        if(isBraking && Vector3.Dot( rb.velocity,transform.up)<0)
        {
            rb.velocity = Vector2.zero;
        }

        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        if (direction >= 0.0f)
        {
            rb.rotation += SteeringAngle * MaxSteering * (rb.velocity.magnitude / 5.0f);
            //rb.AddTorque((h * steering) * (rb.velocity.magnitude / 10.0f));
        }
        else
        {
            rb.rotation -= SteeringAngle * MaxSteering * (rb.velocity.magnitude / 5.0f);
            //rb.AddTorque((-h * steering) * (rb.velocity.magnitude / 10.0f));
        }

        Vector2 forward = new Vector2(0.0f, 0.5f);
        float steeringRightAngle;
        if (rb.angularVelocity > 0)
        {
            steeringRightAngle = -90;
        }
        else
        {
            steeringRightAngle = 90;
        }

        Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
        Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));

        Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);


        Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(relativeForce), Color.red);

        rb.AddForce(rb.GetRelativeVector(relativeForce));
    }
    private void FrontRayTrace()
    {
        RaycastHit2D hit = Physics2D.Raycast(frontTracePosition.position, transform.up, 5f);
        FrontRayResult.isHit = hit;
        if (hit)
        {
            FrontRayResult.hitObject = hit.transform.gameObject;
            FrontRayResult.distance = hit.distance;
            FrontRayResult.angle = 0;
        }
  
    }
    public class RayTraceResult
    {
        public bool isHit;
        public GameObject hitObject;
        public float distance;
        public float angle;
    }
}
