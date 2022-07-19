using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake() // use awake to make sure this happens before anything else.
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() // will call this method the moment this object is destroyed.
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null) // we have contructed the method this way to avoid any null references. When we ended our level by trying again, the scene would destroy "level controller"
                                    // before the remaining attackers and then this method was couldn't find it to run this routuine. With this method, we are saying that if you cant find
                                    // the level controller, don't do anything, if it does fine one, proceed with the below.
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); // moves the attacker left at the speed dictated by our "currentSpeed" float.
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed (float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) //when we call this method we are feeding in the defender (target) that we want the attacker to attack.
    {
        GetComponent<Animator>().SetBool("isAttacking", true); // changes our animator param (bool) "isAttacking" to true which will trigger the animation change.
        currentTarget = target; // sets our GameObject called "currentTarget" to the to what was feed into the method when it was called.
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; } // if nothing has been set to "currentTarget", don't continue any further (return). The exclamation mark (!) here means "is not/does not"
        Health health = currentTarget.GetComponent<Health>(); // create object "health" and access the current target's "Health" script (if it has one).
        if (health) // if "health" exists as in the above line found a "Health" component/script on the object.
        {
            health.DealDamage(damage); // access the object's "Health" script and call the "DealDamage" method, passing in the "damage" float passed into this method when called.
        }
        else { return; }
    }

}
