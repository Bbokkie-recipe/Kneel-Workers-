using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] bgm;
    public Sound[] playerSound;
    public Sound[] enemySound;
    public Sound[] sfxSound;
    public static AudioManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in bgm)
        {
            s.audSrc = gameObject.AddComponent<AudioSource>();
            s.audSrc.clip = s.clip;
            s.audSrc.volume = s.volume;
            s.audSrc.pitch = s.pitch;
            s.audSrc.loop = s.loop;
        }

        foreach (Sound s in playerSound)
        {
            s.audSrc = gameObject.AddComponent<AudioSource>();
            s.audSrc.clip = s.clip;
            s.audSrc.volume = s.volume;
            s.audSrc.pitch = s.pitch;
        }

        foreach (Sound s in enemySound)
        {
            s.audSrc = gameObject.AddComponent<AudioSource>();
            s.audSrc.clip = s.clip;
            s.audSrc.volume = s.volume;
            s.audSrc.pitch = s.pitch;
        }
    }



    public void UpdateMusic(float val)
    {
        foreach (Sound s in bgm)
        {
            s.audSrc.volume = val;
        }
    }
    public void UpdateSFX(float val)
    {
        foreach (Sound s in playerSound)
        {
            s.audSrc.volume = val;
        }
        foreach (Sound s in enemySound)
        {
            s.audSrc.volume = val;
        }
        foreach (Sound s in sfxSound)
        {
            s.audSrc.volume = val;
        }
    }

    void Start()
    {
        BGMPlay("ThemeMusic");
    }
    void Update()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        if (currScene == 3)
        {
            BGMStop("ThemeMusic");
        }
    }

    public void BGMPlay(string _name)
    {
        foreach (Sound s in bgm)
        {
            if (s.name == _name)
            {
                s.audSrc.Play();
            }
        }
    }

    public void BGMStop(string _name)
    {
        foreach (Sound s in bgm)
        {
            if (s.name == _name)
            {
                s.audSrc.Stop();
            }
        }
    }
    public void PlayerPlay(string _name)
    {
        foreach (Sound s in playerSound)
        {
            if (s.name == _name)
            {
                s.audSrc.Play();
            }
        }
    }
    public void EnemyPlay(string _name)
    {
        foreach (Sound s in enemySound)
        {
            if (s.name == _name)
            {
                s.audSrc.Play();
            }
        }
    }

}
