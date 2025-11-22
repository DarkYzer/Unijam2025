using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static int playerAmount;
    public float speed;
    public float imgSize;
    public KeyCode d = KeyCode.D;
    public KeyCode q = KeyCode.Q;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Bonhomme myBonhomme = collision.otherCollider.GetComponent<Bonhomme>();
        Bonhomme otherBonhomme = collision.collider.GetComponent<Bonhomme>();

        if (otherBonhomme == null) return;

        // POSITIONS MONDE AVANT DE TOUCHER AU PARENT
        Vector3 myPos = collision.otherCollider.transform.position;
        Vector3 otherPos = collision.collider.transform.position;

        Vector2 newCoord = myBonhomme.localCoord;

        float offset = imgSize / 2f;

        // ---- DÉTECTION DIRECTION ----
        if (otherPos.x > myPos.x + offset)
            newCoord += Vector2.right;

        else if (otherPos.x < myPos.x - offset)
            newCoord += Vector2.left;

        else if (otherPos.y > myPos.y + offset)
            newCoord += Vector2.up;

        else if (otherPos.y < myPos.y - offset)
            newCoord += Vector2.down;

        Debug.Log($"myPos={myPos}, otherPos={otherPos}, newCoord={newCoord}");

        // ---- ATTACH ----
        Transform otherT = collision.collider.transform;
        otherT.SetParent(transform);

        otherBonhomme.localCoord = newCoord;

        // ---- PLACEMENT ----
        otherT.localPosition = new Vector3(
            newCoord.x * offset,
            newCoord.y * offset,
            0
        );

        Debug.Log($"localCoord modifié = {otherBonhomme.localCoord}");
    }

    void Update()
    {
        if (Input.GetKey(d)) transform.position += Vector3.right * speed * Time.deltaTime;
        if (Input.GetKey(q)) transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
