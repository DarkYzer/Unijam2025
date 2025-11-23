using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    public AudioSource audioSource;
    void Update()
    {
        Debug.Log($"----{ AudioSliderScript.volume}");
        audioSource.volume = AudioSliderScript.volume;
    }
}
