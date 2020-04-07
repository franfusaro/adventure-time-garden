using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Star : MonoBehaviour
{
    [SerializeField] float collectedSpeed = 1f;
    [SerializeField] int starsToAdd = 25;

    float spawnSpeed = 0.75f;
    StarSink starSink;
    bool collected = false;
    Vector3 endSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        starSink = FindObjectOfType<StarSink>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            HandleStarCollected();
        }
        else
        {
            if (transform.position != endSpawnPosition)
            {
                Vector2 new2DPosition = Vector2.MoveTowards(transform.position, endSpawnPosition, spawnSpeed * Time.deltaTime);
                transform.position = new Vector3(new2DPosition.x, new2DPosition.y, -1); //-1 in Z so star collider goes in front of trophy collider
            }
        }
    }

    private void HandleStarCollected()
    {
        if (starSink)
        {
            transform.position = Vector2.MoveTowards(transform.position, starSink.transform.position, collectedSpeed * Time.deltaTime);
            //transform.Translate(starSink.transform.position * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("StarSink"))
        {
            FindObjectOfType<StarDisplay>().AddStars(starsToAdd);
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        collected = true;
    }

    public void SetEndSpawnPosition(Vector3 newEndSpawnPosition)
    {
        endSpawnPosition = newEndSpawnPosition;
    }

    public void SetSpawnSpeed(float newSpawnSpeed)
    {
        spawnSpeed = newSpawnSpeed;
    }
}
