using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreenUI : MonoBehaviour
{   
    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}