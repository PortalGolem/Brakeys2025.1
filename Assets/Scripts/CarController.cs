using System.ComponentModel.Design;
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
        
        speed += breakInput * breakForce;
        if (speed > maxSpeed){
            speed = maxSpeed;
        }
        if (speed < minimumSpeed){
            speed = minimumSpeed;
        }
        

        rb.linearVelocity = (rb.linearVelocity - (transform.forward * rb.linearVelocity.magnitude)) + (speed * transform.forward);
    }

    public void Accelerate(InputAction.CallbackContext context){
        accelerationInput = context.ReadValue<float>();
        print(accelerationInput);
    }
    public void Break(InputAction.CallbackContext context){
        breakInput = context.ReadValue<float>();
    } 
    public void Steer(InputAction.CallbackContext context){
        steerInput = context.ReadValue<float>();
    }
}
