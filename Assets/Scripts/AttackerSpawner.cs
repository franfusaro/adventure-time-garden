using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;

    // Start is called before the first frame update
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
        int selectedAttacker = Random.Range(0, attackers.Length);
        Spawn(attackers[selectedAttacker]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, attacker.transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
