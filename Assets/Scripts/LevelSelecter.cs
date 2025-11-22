using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelecter : MonoBehaviour
{
    public void ChangeToLevel(int x)
    {
        SceneManager.LoadScene($"Niveau{x}");
    }
}
