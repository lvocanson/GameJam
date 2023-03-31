using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip click;
    [SerializeField] AudioClip[] dialogue;
    [SerializeField] AudioClip audioStartGame;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play a sound effect.
    /// </summary>
    /// <param name="clip">Clip to play</param>
    void Play(AudioClip clip) => audioSource.PlayOneShot(clip);

    public void PlayClick() => Play(click);
    public void PlayDialogue() => Play(dialogue[Random.Range(0, dialogue.Length)]);
    public void PlayAudioStartGame() => Play(audioStartGame);

    /// <summary>
    /// Change the volume of the audio source.
    /// </summary>
    /// <param name="value">New value (between 0 and 1)</param>
    public void ChangeVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("volume", value);
    }
}
