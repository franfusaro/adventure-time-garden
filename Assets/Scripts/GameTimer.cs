using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    [Tooltip ("Level time in SECONDS")]
    [SerializeField] float levelTime = 10f;
    Slider slider;
    bool triggeredLevelFinished = false;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }
        slider.value = Time.timeSinceLevelLoad / levelTime;
        if (IsLevelTimerFinished())
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }

    public bool IsLevelTimerFinished()
    {
        return (Time.timeSinceLevelLoad >= levelTime);
    }
}
