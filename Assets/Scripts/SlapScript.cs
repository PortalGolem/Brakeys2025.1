using UnityEngine;

public class SlapScript : MonoBehaviour
{
    HealthScript healthScript;
    [SerializeField] float carCollisionDamage = 1;
    [SerializeField] float slapBackDamage = 0;

    void Start()
    {
        healthScript = gameObject.GetComponent<HealthScript>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.GetComponent<CarController>() != null && healthScript.health > 0){
            healthScript.Damage(carCollisionDamage);
            if (slapBackDamage > 0){
                collision.collider.gameObject.GetComponent<HealthScript>().Damage(slapBackDamage);
            }
        }
    }
}
