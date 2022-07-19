using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D otherCollider) // "otherCollider" will be the other collider that the object with this script collided with such as a defender or another attacker.
                                                            // So later on in our code, "otherCollider" will only be the actual collider of the object it collided with, not the object itself.
    {
        GameObject otherObject = otherCollider.gameObject; // create "otherObject" of type GameObject and make it the object we collided with. 
                                                           // "otherCollider.gameObject" means the actual object that belongs to the collider we collided with.

        if (otherObject.GetComponent<Defender>()) // if the object we just collided with has the "Defender" script attached to it...
        {
            GetComponent<Attacker>().Attack(otherObject); //accesses the "Attacker" script and calls the "Attack" method, feeding in the Defender (otherObject) defined above.
        }
    }

}
