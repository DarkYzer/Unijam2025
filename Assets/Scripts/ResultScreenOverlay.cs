using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreenOverlay : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

        public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
