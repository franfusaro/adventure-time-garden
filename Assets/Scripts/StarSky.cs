using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSky : MonoBehaviour
{
    [SerializeField] float timeBetweenStarsSpawn = 1f;
    [SerializeField] Star newStarPrefab;
    [SerializeField] float minSpawnSpeed = 5f;
    [SerializeField] float maxSpawnSpeed = 7f;

    [SerializeField] float minYEndPos = 1f;
    [SerializeField] float maxYEndPos = 5f;
    [SerializeField] float minXEndPos = 1f;
    [SerializeField] float maxXEndPos = 6f;


    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStars());
    }

    IEnumerator SpawnStars()
    {
        yield return new WaitForSeconds(timeBetweenStarsSpawn);
        while (spawn)
        {
            Star star = Instantiate(newStarPrefab, transform.position, transform.rotation) as Star;
            star.SetEndSpawnPosition(new Vector3(Random.Range(minXEndPos, maxXEndPos), Random.Range(minYEndPos, maxYEndPos), 0));
            star.SetSpawnSpeed(Random.Range(minSpawnSpeed, maxSpawnSpeed));
            yield return new WaitForSeconds(timeBetweenStarsSpawn);
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }
    
}
