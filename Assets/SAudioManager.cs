using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public partial class SAudioManager : MonoBehaviour
{
    private bool isMusicDutchmanLevelPlaying = false;
    private bool isMusicMazeAndHub = false;
    public Sound[] sounds;

    public static SAudioManager instance;
    //AudioManager

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string loadedSceneName = scene.name;
        if (loadedSceneName == "DayTime" || loadedSceneName == "NightTime")
        {
            Stop("MusicMazeAndHub");
            isMusicMazeAndHub = false;
            AudioSource[] audioSources = GetComponents<AudioSource>();

            foreach (AudioSource source in audioSources)
            {
                if (source.clip != null && source.clip.name == "MusicDutchmanLevel")
                {
                    if(source.isPlaying)
                        isMusicDutchmanLevelPlaying= true;
                }
            }
            if (!isMusicDutchmanLevelPlaying)
            {
                Play("MusicDutchmanLevel");
            }
            Play("WindSailsRope");
        }
        else
        {
            isMusicDutchmanLevelPlaying= false;
            Stop("WindSailsRope");
            Stop("MusicDutchmanLevel");
            AudioSource[] audioSources = GetComponents<AudioSource>();

            foreach (AudioSource source in audioSources)
            {
                if (source.clip != null && source.clip.name == "MusicMazeAndHub")
                {
                    if (source.isPlaying)
                        isMusicMazeAndHub = true;
                }
            }
            if (!isMusicMazeAndHub)
            {
                Play("MusicMazeAndHub");
            }
        }
    }


    void Start()
    {
        //Play("Theme");

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    //this addition to the code was made by me, the rest was from Brackeys tutorial
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }

    public void DialogueTick()
    {
        Play("DialogueTickSound");
    }
}