using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioStation : MonoBehaviour
{

    public AudioClip[] audioSongs;

    public AudioClip[] audioHints;

    AudioSource audioSource;

    public bool playingSong;

    public int randomIndexSongs;
    public int randomIndexHints;

    public Text songText;
    RadioManager radioManager;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        randomIndexSongs = Random.Range(0, audioSongs.Length);
        randomIndexHints = Random.Range(0, audioHints.Length);

        audioSource.clip = audioHints[randomIndexHints];

        StartCoroutine(AudioPlaySequence());

        radioManager = gameObject.GetComponentInParent<RadioManager>();
    }

    void Update()
    {
        if(audioSource.clip == audioSongs[randomIndexSongs])
        {
            songText.text = audioSource.clip.name;
            Debug.Log("is it wokring?");
        }
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
