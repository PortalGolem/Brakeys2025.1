using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControllerScript : MonoBehaviour
{
    [SerializeField] float sensitivity;
    private Vector3 LookRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = LookRotation;
        newRotation *= sensitivity;
        newRotation = new Vector3(-LookRotation.y, LookRotation.x, 0);
        transform.rotation = Quaternion.Euler(newRotation + transform.rotation.eulerAngles);
    }

    public void Look(InputAction.CallbackContext context){
        LookRotation = context.ReadValue<Vector2>();
    }
}
