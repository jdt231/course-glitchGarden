using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        CreateProjectileParent();
        SetLaneSpawner();
        animator = GetComponent<Animator>(); // here we are accesing the animator on our gameobject so we can change the animation when an Attacker spawns in our Defenders lane (or is destroyed).
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true); // set the "isAttacking" param of our animator to true which will change the animation to "Cactus Attack"
        }
        else
        {
            animator.SetBool("isAttacking", false); // set the "isAttacking" param of our animator to false which will change the animation to "Cactus Idle"
        }
    }
   
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>(); // creates an array called "spawners" of all objects that contain the script "AttackerSpawner" (our spawners).

        foreach (AttackerSpawner spawner in spawners) // for every "spawner" (variable) found within our "spawner" array, is this in the same lane as our gameobject (Defender/Shooter)?
        {
            bool isCloseEnough = // determining if a spawner is in the same lane as the object with the "ShooterScript"
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) // the spawners y position and the defender/shooter's y position should be the same so this should equal zero.
                <= Mathf.Epsilon); // calculations like the above don't always equal exactly zero, so using "<= Mathf.Epsilon" will ensure it takes this into account and round it.
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject; 
        newProjectile.transform.parent = projectileParent.transform;
    }

}
