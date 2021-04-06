using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] float levelTime = 60f;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        triggeredLevelFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (triggeredLevelFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }
}
