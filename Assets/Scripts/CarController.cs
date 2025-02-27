using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public bool isRunning = true;
    [SerializeField] private float acceleration = .1f;
    [SerializeField] private float maxSpeed = 25;
    [SerializeField] private float breakForce = 1;
    [SerializeField] private float steerForce = 1;
    [SerializeField] private float minimumSpeed;
    [SerializeField] public float decelerationPerTick = 0;
    [SerializeField] private float groundCheckDistance = .5f;
    [SerializeField] private LayerMask groundLayer;

    [HideInInspector] public float speed;
    [HideInInspector] public float breakInput;
    [HideInInspector] public float steerInput;
    [HideInInspector] public float accelerationInput;


    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += accelerationInput * acceleration;
        if (speed - decelerationPerTick > 0){
            speed -= decelerationPerTick;
        }
        else{
            speed += decelerationPerTick;
        }
        
        speed += breakInput * breakForce;
        if (speed > maxSpeed){
            speed = maxSpeed;
        }
        if (speed < minimumSpeed){
            speed = minimumSpeed;
        }
        if (onGround()){
            rb.angularVelocity = transform.up * steerInput * steerForce; 

            rb.linearVelocity =  rb.linearVelocity - (transform.forward * Vector3.Dot(rb.linearVelocity, transform.forward) ) + (speed * transform.forward);
        }
    }

    private bool onGround(){
        return Physics.Raycast(transform.position, Quaternion.AngleAxis(180, transform.right) * transform.up, groundCheckDistance, groundLayer);
    }

    public void Accelerate(InputAction.CallbackContext context){
        accelerationInput = context.ReadValue<float>();
    }
    public void Break(InputAction.CallbackContext context){
        breakInput = context.ReadValue<float>();
    } 
    public void Steer(InputAction.CallbackContext context){
        steerInput = context.ReadValue<float>();
    }
}
