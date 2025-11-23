using UnityEngine;
using UnityEngine.UI;

public class AudioSliderScript: MonoBehaviour
{
    public static float volume;
    public AudioSource audioPlayer;
    public Slider slider;

    void Update()
    {
        volume = slider.value;
    }
}
