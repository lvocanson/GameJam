using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] AudioClip[] click;
    [SerializeField] AudioClip[] dialogue;
    [SerializeField] AudioClip backgroundMusicMenu;
    [SerializeField] AudioClip backgroundMusicGame;

    private float volume = 1f;

    /// <summary>
    /// Play a sound effect.
    /// </summary>
    /// <param name="clip">Clip to play</param>
    void Play(AudioClip clip) => AudioSource.PlayClipAtPoint(clip, Vector2.zero, volume);

    public void PlayClick() => AudioSource.PlayClipAtPoint(click[Random.Range(0, click.Length)], Vector2.zero, volume);
    public void PlayDialogue() => AudioSource.PlayClipAtPoint(dialogue[Random.Range(0, dialogue.Length)], Vector2.zero, volume);
    public void PlayBGMenu() => AudioSource.PlayClipAtPoint(backgroundMusicMenu, Vector3.zero, volume);
    public void PlayBGGame() => AudioSource.PlayClipAtPoint(backgroundMusicGame, Vector2.zero, volume);

    /// <summary>
    /// Change the volume of the audio source.
    /// </summary>
    /// <param name="value">New value (between 0 and 1)</param>
    public float Volume { get => volume; set => volume = value;}
}
