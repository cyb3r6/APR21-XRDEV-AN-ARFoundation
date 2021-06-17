using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTouchController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float turnSpeed = 30f;
    public float deadZone = 0.2f;

    private Animator robotAnim;
    private Rigidbody robotRigidbody;
    private Joystick joystick;

    void OnEnable()
    {
        joystick = FindObjectOfType<Joystick>();
        robotRigidbody = GetComponent<Rigidbody>();
        robotAnim = GetComponent<Animator>();
        robotAnim.SetBool("Open_Anim", true);
    }

    
    void Update()
    {
        if(joystick.Direction.magnitude >= deadZone)
        {
            robotRigidbody.AddForce(transform.forward * moveSpeed);
            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            robotAnim.SetBool("Walk_Anim", false);
        }

        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
        Vector3 directionToRotateIn = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * turnSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(directionToRotateIn);
    }
}
