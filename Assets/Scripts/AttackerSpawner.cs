using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    float DIFFICULTY_SPAWN_SECONDS = 3f;

    bool spawn = true;
    [SerializeField] float startSpawnDelay = 15f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(CalculateStartSpawnDelay());
        //yield return new WaitForSeconds(Random.Range(CalculateStartSpawnDelay(minSpawnDelay), CalculateStartSpawnDelay(maxSpawnDelay)));
        while (spawn)
        {
            SpawnAttacker();
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
    
    public void StopSpawning()
    {
        spawn = false;
    }

    private float CalculateStartSpawnDelay()
    {
        return startSpawnDelay - PlayerPrefsController.GetDifficulty() * DIFFICULTY_SPAWN_SECONDS;
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
