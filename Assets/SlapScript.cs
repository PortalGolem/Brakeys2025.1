using UnityEngine;

public class SlapScript : MonoBehaviour
{
    HealthScript healthScript;
    [SerializeField] float carCollisionDamage = 1;

    void Start()
    {
        healthScript = gameObject.GetComponent<HealthScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.GetComponent<CarController>() != null){
            healthScript.Damage(carCollisionDamage);
        }
    }
}
