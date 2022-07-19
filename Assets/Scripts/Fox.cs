using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D otherCollider) // Same as "Lizard"
    {
        GameObject otherObject = otherCollider.gameObject; // Same as "Lizard" 

        if (otherObject.GetComponent<Gravestone>()) // if the object we have collided with has a "Gravestone" component.
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger"); // activate our animation param/trigger "jumpTrigger" to make the fox jump
        }

        else if (otherObject.GetComponent<Defender>()) // Same as "Lizard" 
        {
            GetComponent<Attacker>().Attack(otherObject); // Same as "Lizard" 
        }
    }

}
