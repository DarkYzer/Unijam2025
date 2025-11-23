using UnityEngine;

public sealed class AudioPlayerScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioSource _loopAudioSource;

    [SerializeField]
    private AudioSource _walkAudioSource;

    public static AudioPlayerScript Singleton { get; private set; }

    [SerializeField]
    private AudioClip[] _audioClips;

    public bool WalkSoundPlaying
    {
       get => _walkAudioSource.isPlaying;
        set
        {
            if (value && !_walkAudioSource.isPlaying)
                _walkAudioSource.Play();
            else if (!value && _walkAudioSource.isPlaying)
                _walkAudioSource.Stop();
        }
    }

    public enum SoundType : int
    {
        None,
        DefaultTheme,
        Entry,
        Success,
        Failure,
        Snap,
        Walk,
    }

    private void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        _loopAudioSource.volume = AudioSliderScript.volume;
        _audioSource.volume = AudioSliderScript.volume;
        _walkAudioSource.volume = AudioSliderScript.volume * 0.1f;
    }

    public void PlaySound(SoundType type)
    {
        //AudioClip[] clips = _audioClips[(int)type];

        //if (clips.Length > 0)
        //_audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)], volume);

        _audioSource.PlayOneShot(_audioClips[(int)type]);
    }
}