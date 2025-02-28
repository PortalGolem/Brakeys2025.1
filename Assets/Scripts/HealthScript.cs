using UnityEditor.Callbacks;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHealth = 10;
    public float health = 10;

    [SerializeField] float regenIntensity = 0;
    [SerializeField] float ticksToRegen = 0;

    int tickCounter = 0;
    private DeathScript deathScript;

    void Start()
    {
        deathScript = gameObject.GetComponent<DeathScript>();
    }

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
            deathScript.killMe();
        }
    }

    public void Heal(float health){
        health += health;
    }

    
}
