using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator transition;
    private MusicManager musicManager;

    private void Awake()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    public void Change()
    {
        musicManager.pressBtn();
        new WaitForSeconds(0.5f);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ChangeSceneName(string SceneName)
    {
        musicManager.pressBtn();
        new WaitForSeconds(0.5f);
        StartCoroutine(LoadLevelName(SceneName));
    }

    public void Repeat()
    {
        musicManager.pressBtn();
        new WaitForSeconds(0.5f);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void ReturnPrevScene()
    {
        musicManager.pressBtn();
        new WaitForSeconds(0.5f);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");   

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadLevelName(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(levelName);
    }
}
