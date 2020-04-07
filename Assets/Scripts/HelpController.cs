using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    [SerializeField] GameObject[] helps;
    int currentHelpIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void LoadNextHelp()
    {
        helps[currentHelpIndex].SetActive(false);
        currentHelpIndex++;
        helps[currentHelpIndex].SetActive(true);
    }

    public void EndHelp()
    {
        helps[currentHelpIndex].SetActive(false);
        Time.timeScale = 1;
    }
}
