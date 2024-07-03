using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public AudioSource bgm;
    public AudioSource sfx;
    private bool isChangingScence = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void pressBtn()
    {
        sfx.Play();
    }

    public void setIsChangingScence(bool value)
    {
        isChangingScence = value;
    }

    public void Update()
    {
        if (SceneManager.GetSceneByName("MainPage").isLoaded)
        {
            bgm.Pause();
        }
        else
        {
            bgm.UnPause();
        }
    }
}
