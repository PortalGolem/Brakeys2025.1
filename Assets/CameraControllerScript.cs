using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControllerScript : MonoBehaviour
{
    [SerializeField] float sensitivity;
    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;
    private Vector3 LookRotation;
    private Vector3 localRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = (new Vector3(-LookRotation.y, LookRotation.x, 0) * sensitivity) + localRotation;
        newRotation.x = Mathf.Clamp(newRotation.x, minHeight, maxHeight);
        localRotation = newRotation;
        transform.localEulerAngles = newRotation;
    }

    public void Look(InputAction.CallbackContext context){
        LookRotation = context.ReadValue<Vector2>();
    }
}
