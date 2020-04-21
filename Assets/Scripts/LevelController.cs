using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int waitTimeUntilNextLevel = 4;

    int attackersAlive = 0;
    bool isLevelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        attackersAlive++;
    }

    public void AttackerKilled()
    {
        attackersAlive--;
        if (IsLevelFinished())
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public bool IsLevelFinished()
    {
        return attackersAlive <= 0 && isLevelTimerFinished;
    }

    IEnumerator HandleWinCondition()
    {
        StopStarDrop();
        yield return new WaitForSeconds(1);
        winLabel.SetActive(true);
        AudioSource winSound = GetComponent<AudioSource>();
        if (winSound)
        {
            winSound.volume = PlayerPrefsController.GetMasterVolume();
            winSound.Play();
        }
        yield return new WaitForSeconds(waitTimeUntilNextLevel);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
        StopSpawners();
    }

    public void LevelTimerFinished()
    {
        isLevelTimerFinished = true;
        StopSpawners();
    }

    public void StopStarDrop()
    {
        FindObjectOfType<StarSky>().StopSpawning();
    }

    public void StopSpawners()
    {
        AttackerSpawner[] attackerSpawnersArray = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in attackerSpawnersArray)
        {
            spawner.StopSpawning();
        }
    }

}
