using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
