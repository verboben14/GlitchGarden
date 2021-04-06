using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitBeforeWin = 4f;
    int enemyCount = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void IncreaseEnemyCount()
    {
        enemyCount++;
    }

    public void DecreaseEnemyCount()
    {
        enemyCount--;
        if(CheckTimerFinished() && enemyCount <= 0)
        {
            StartCoroutine(HandleWin());
        }
    }

    private IEnumerator HandleWin()
    {
        winLabel?.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitBeforeWin);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLose()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        CheckTimerFinished();
    }

    private bool CheckTimerFinished()
    {
        if(levelTimerFinished)
        {
            StopSpawners();
        }
        return levelTimerFinished;
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
