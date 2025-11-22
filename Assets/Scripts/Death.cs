using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [Tooltip("Caméra utilisée pour le test. Si null, Camera.main sera utilisée.")]
    public Camera targetCamera;

    [Tooltip("Tolérance en dehors du viewport (valeurs positives étendent la zone)")]
    [Range(0f, 0.5f)]
    public float viewportMargin = 0.0f;

    [Tooltip("Si vrai : recharge la scène quand le joueur sort de la vue. Sinon : téléporte au point de respawn.")]
    public bool reloadSceneOnExit = true;

    [Tooltip("Point où téléporter le joueur si reloadSceneOnExit == false. Si null, la position de départ sera utilisée.")]
    public Transform respawnPoint;

    // position/rotation de départ (utilisée si respawnPoint == null)
    private Vector3 startPosition;
    private Quaternion startRotation;

    // empêche de déclencher plusieurs fois durant la même sortie
    private bool hasExited = false;

    private void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main;
        }

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (targetCamera == null || hasExited)
            return;

        Vector3 vp = targetCamera.WorldToViewportPoint(transform.position);

        // vp.z < 0 -> derrière la caméra
        bool outside = vp.z < 0f
                       || vp.x < -viewportMargin
                       || vp.x > 1f + viewportMargin
                       || vp.y < -viewportMargin
                       || vp.y > 1f + viewportMargin;

        if (outside)
        {
            hasExited = true;
            HandleExit();
        }
    }

    private void HandleExit()
    {
        if (reloadSceneOnExit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;
            }
            else
            {
                transform.position = startPosition;
                transform.rotation = startRotation;
            }

            // Permet de redétecter une sortie après le respawn
            hasExited = false;
        }
    }
}