using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWaitBeforeStart = 2.5f;
    [SerializeField] float timeToWaitBeforeGameOver = 1.5f;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadStartSceneFromSplash();
    }
    private IEnumerator LoadStartSceneWithTimeToWait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
        currentSceneIndex++;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    public void LoadGameOverScene()
    {
        LoadGameOverSceneWithTimeToWait(timeToWaitBeforeGameOver);
    }

    private IEnumerator LoadGameOverSceneWithTimeToWait(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("Game Over Screen");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadSplashScreen()
    {
        SceneManager.LoadScene(0);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        LoadStartSceneFromSplash();
    }

    private void LoadStartSceneFromSplash()
    {
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartSceneWithTimeToWait(timeToWaitBeforeStart));
        }
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
