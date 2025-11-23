using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [Tooltip("Cam�ra utilis�e pour le test. Si null, Camera.main sera utilis�e.")]
    public Camera targetCamera;

    [Tooltip("Tol�rance en dehors du viewport (valeurs positives �tendent la zone)")]
    [Range(0f, 0.5f)]
    public float viewportMargin = 0.0f;

    [Tooltip("Si vrai : recharge la sc�ne quand le joueur sort de la vue. Sinon : t�l�porte au point de respawn.")]
    public bool reloadSceneOnExit = true;

    [Tooltip("Point o� t�l�porter le joueur si reloadSceneOnExit == false. Si null, la position de d�part sera utilis�e.")]
    public Transform respawnPoint;

    // position/rotation de d�part (utilis�e si respawnPoint == null)
    private Vector3 startPosition;
    private Quaternion startRotation;

    // emp�che de d�clencher plusieurs fois durant la m�me sortie
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

        // vp.z < 0 -> derri�re la cam�ra
        bool outside = vp.z < 0f
                       || vp.x < -viewportMargin
                       || vp.x > 1f + viewportMargin
                       || vp.y < -viewportMargin;

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

            // Permet de red�tecter une sortie apr�s le respawn
            hasExited = false;
        }
    }
}