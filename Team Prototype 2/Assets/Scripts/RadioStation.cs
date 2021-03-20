using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStation : MonoBehaviour
{

    public AudioClip[] audioSongs;

    public AudioClip[] audioHints;

    AudioSource audioSource;

    public bool playingSong;

    public int randomIndexSongs;
    public int randomIndexHints;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        randomIndexSongs = Random.Range(0, audioSongs.Length);
        randomIndexHints = Random.Range(0, audioHints.Length);

        audioSource.clip = audioHints[randomIndexHints];

        StartCoroutine(AudioPlaySequence());
    }

    IEnumerator AudioPlaySequence()
    {
        audioSource.Play();

        yield return new WaitForSeconds(audioHints[randomIndexHints].length);

        randomIndexSongs = Random.Range(0, audioSongs.Length);
        randomIndexHints = Random.Range(0, audioHints.Length);

        yield return new WaitForSeconds(1f);

        audioSource.clip = audioSongs[randomIndexSongs];
        audioSource.Play();

        yield return new WaitForSeconds(audioSongs[randomIndexSongs].length);

        randomIndexHints = Random.Range(0, audioHints.Length);
        randomIndexSongs = Random.Range(0, audioSongs.Length);

        yield return new WaitForSeconds(1f);

        audioSource.clip = audioHints[randomIndexHints];

        yield return new WaitForSeconds(1f);

        if (!audioSource.isPlaying)
        {
            StartCoroutine(AudioPlaySequence());
        }

    }
}
