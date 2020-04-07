using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSky : MonoBehaviour
{
    [SerializeField] float timeBetweenStarsSpawn = 1f;
    [SerializeField] Star newStarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStars());
    }

    IEnumerator SpawnStars()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenStarsSpawn);
            Star star = Instantiate(newStarPrefab, transform.position, transform.rotation) as Star;
            star.SetEndSpawnPosition(new Vector3(Random.Range(1f, 6f), Random.Range(1f, 5f), 0));
            star.SetSpawnSpeed(Random.Range(5f, 7f));
        }
    }
    
}
