using UnityEngine;

public sealed class AudioPlayerScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioSource _loopAudioSource;

    public static AudioPlayerScript Singleton { get; private set; }

    [SerializeField]
    private AudioClip[] _audioClips;

    public enum SoundType : int
    {
        None,
        DefaultTheme,
        Entry,
        Success,
        Failure,
    }

    private void Awake()
    {
        Singleton = this;
    }

    public void PlaySound(SoundType type, float volume)
    {
        //AudioClip[] clips = _audioClips[(int)type];

        //if (clips.Length > 0)
        //_audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)], volume);

        _audioSource.PlayOneShot(_audioClips[(int)type], volume);
    }
}