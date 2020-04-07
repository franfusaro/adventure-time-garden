using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 12;

    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentSceneIndex);
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    private IEnumerator WaitForTime()
    {
        Debug.Log("waiting for " + timeToWait);
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void LoadNextScene()
    {
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadYouLoseScene()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
