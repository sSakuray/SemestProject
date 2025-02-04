using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    #region Attributes
    public List<AudioClip> MusicSounds = new();
    private AudioSource musicSource;

    AudioClip current;

    private float Lenght;

    private Coroutine loopcor;

    private MusicQueue musicQueue;
    #endregion

    #region MonoBehaivorAPI

    private void Start()
    {
        musicQueue = new MusicQueue(MusicSounds);

        musicSource = GetComponent<AudioSource>();

        StartMusic();
    }

    #endregion

    public void PlayMusicClip(AudioClip clip)
    {
        musicSource.Stop();
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        if (loopcor != null) StopCoroutine(loopcor);
    }

    public void StartMusic()
    {
        loopcor = StartCoroutine(musicQueue.Loopienum(this,0,PlayMusicClip));
    }
}

public class MusicQueue
{
    List<AudioClip> MusicSounds;
    public IEnumerator Loopienum(MonoBehaviour Aplayer, float delay, System.Action<AudioClip> playfunction)
    {
        while (true)
        {
            yield return  Aplayer.StartCoroutine(RunMusic(randomizedlist(MusicSounds), delay, playfunction));
        }

    }
    public IEnumerator RunMusic(List<AudioClip> clips, float delay, System.Action<AudioClip> playfunction)
    {
        foreach (AudioClip clip in clips)
        {
            playfunction(clip);

            yield return new WaitForSeconds(clip.length+delay);
        }
    }

    public List<AudioClip> randomizedlist(List<AudioClip> clips)
    {
        List<AudioClip> copy = clips;
        int i = copy.Count;
        while (i>0)
        {
            i--;
            int rnd = UnityEngine.Random.Range(0, i+1);
            AudioClip clip = copy[rnd];

            copy[rnd] = copy[i];
            copy[i] = clip;
        }
        return copy;
    }
    public MusicQueue(List<AudioClip> clips)
    {
        MusicSounds = clips;
    }
}