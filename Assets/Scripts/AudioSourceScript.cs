using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    public AudioSource audioSource;
    void Update()
    {
        audioSource.volume = AudioSliderScript.volume;
    }
}
