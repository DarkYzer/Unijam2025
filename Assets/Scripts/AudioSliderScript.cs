using UnityEngine;
using UnityEngine.UI;

public class AudioSliderScript: MonoBehaviour
{
    public static float volume = 1;
    public AudioSource audioPlayer;
    public Slider slider;

    void Update()
    {
        volume = slider.value;
    }
}
