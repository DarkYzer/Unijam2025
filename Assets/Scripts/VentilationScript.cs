using System.Collections.Generic;
using UnityEngine;

public sealed class VentilationScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _playerRb;

    [SerializeField]
    private float force = 1;

    [SerializeField]
    private float maxDistance = 5;

    void Update()
    {
        Vector3 raycastOrigin = transform.position + 0.51f * transform.localScale.x * transform.right;

        List<Bonhomme> bonhommes = new();

        int raycastCount = Mathf.RoundToInt(2 * transform.localScale.y);

        Vector3 offset = transform.up * 0.5f;

        for (int i = - raycastCount / 2; i < raycastCount / 2 + 1; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin + i * offset, transform.right, maxDistance);
            if (hit && hit.collider.gameObject.TryGetComponent(out Bonhomme bonhomme) && bonhomme.IsConnected && !bonhommes.Contains(bonhomme))
            {
                bonhommes.Add(bonhomme);
                _playerRb.AddForce(force * transform.right);
            }
        }
    }
}