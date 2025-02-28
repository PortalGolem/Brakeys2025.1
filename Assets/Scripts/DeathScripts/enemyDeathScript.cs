using UnityEngine;

public class enemyDeathScript : DeathScript
{
    public override void killMe()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.mass = 0;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.None;
    }
}
