using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreenUI : MonoBehaviour
{
    private void Start()
    {
        AudioPlayerScript.Singleton.PlaySound(AudioPlayerScript.SoundType.Success);
    }
    
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}