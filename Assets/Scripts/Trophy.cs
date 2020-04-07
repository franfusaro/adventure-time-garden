using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] float timeBetweenStarsSpawn = 5f;
    [SerializeField] Star newStarPrefab;

    [SerializeField] float starSpawnXDelta = 0.5f;
    [SerializeField] float starSpawnYDelta = 0.15f;

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
            star.SetEndSpawnPosition(transform.position + new Vector3(Random.Range(-starSpawnXDelta, starSpawnXDelta), Random.Range(-starSpawnYDelta, starSpawnYDelta), 0));
            star.SetSpawnSpeed(0.75f);
        }
    }
    
}
