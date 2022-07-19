using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length); // create attackerIndex and set it to a number between 0 and the amount of things held within our "attackerPrefabArray".

        Spawn(attackerPrefabArray[attackerIndex]); // calling the "Spawn" method and passing in the number determined above. If our array has 5 attackers held within it, the above line will
                                                   // pick a number between 0 and 4 (because 0 is the first in the array) and this will determine what attacker in our array will be spawned.
      
    }

    private void Spawn(Attacker myAttacker) // So the "SpawnAttacker" method above has picked an attacker from our array and passed it into this method.
    {
        Attacker newAttacker = Instantiate // Instantiates the attacker as a "newAttacker" of type "Attacker".
            (myAttacker, transform.position, transform.rotation) // "myAttacker" here is the attacker prefab passed into this method from "SpawnAttacker".
            as Attacker; // this is still required even though we used "Attacker newAttacker" earlier.

        newAttacker.transform.parent = transform; // this sets the newly instantiated attacker as a child to the parent object which is this spawner. "transform" refers to this spawner.
    }
}
