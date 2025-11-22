using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void TestVictory()
    {
        SceneManager.LoadScene("Victory");
    }

        public void TestDefeat()
    {
        SceneManager.LoadScene("Defeat");
    }
}
