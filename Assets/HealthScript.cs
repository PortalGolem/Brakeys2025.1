using UnityEditor.Callbacks;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHealth = 10;
    public float health = 10;

    [SerializeField] float regenIntensity = 0;
    [SerializeField] float ticksToRegen = 0;

    int tickCounter = 0;

    void FixedUpdate()
    {
        tickCounter++;
        if (tickCounter >= ticksToRegen){
            health += regenIntensity;
        }
    }

    public void Damage(float damage){
        health -= damage;
        if (health <= 0){
            kill();
        }
    }

    public void Heal(float health){
        health += health;
    }

    private void kill(){
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.mass = 0;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.None;
    }
}
