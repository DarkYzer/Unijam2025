using UnityEngine;

public class AudioSlider: MonoBehaviour
{
    public static float volume;
    public AudioSource audioPlayer;

    void Update()
    {
        volume = audioPlayer.volume;
    }
}
