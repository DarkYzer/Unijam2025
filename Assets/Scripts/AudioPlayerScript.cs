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
        Snap,
    }

    private void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        //_loopAudioSource.volume = AudioSliderScript.volume;
        //_audioSource.volume = AudioSliderScript.volume;
    }

    public void PlaySound(SoundType type)
    {
        //AudioClip[] clips = _audioClips[(int)type];

        //if (clips.Length > 0)
        //_audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)], volume);

        _audioSource.PlayOneShot(_audioClips[(int)type]);
    }
}