using UnityEngine;

public class Death : MonoBehaviour
{
    private float coordY;
    public void DeathZone()
    {
        Bonhomme myBonhomme = GetComponent<Bonhomme>();
        coordY = myBonhomme.localCoord.y;
        if (coordY < -10f)
        {
            // Reset the game or respawn the player
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
