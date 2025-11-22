using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement: MonoBehaviour
{
    public float speed;   
    public float imgSize;
    public Vector3 deplacement;
    public KeyCode d = KeyCode.D;
    public KeyCode q = KeyCode.Q;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D otherCollider = collision.collider;
        Collider2D myCollider = collision.otherCollider;

        Bonhomme myBonhomme = myCollider.GetComponent<Bonhomme>();
        Bonhomme otherBonhomme = otherCollider.GetComponent<Bonhomme>();

        Debug.Log($"{otherCollider.transform.position} | {myCollider.transform.position}");

        if (otherBonhomme != null && collision.gameObject.CompareTag("bonhomme"))
        {
            Vector2 myLocalCoord = myBonhomme.localCoord;
            Debug.Log($"me: {myCollider.name}, other: {otherCollider.name}, myCoord:{myLocalCoord}, otherCoord:{otherBonhomme.localCoord}");

            // Exemple logique droite/gauche/haut/bas
            if (otherCollider.transform.position.x > myCollider.transform.position.x + imgSize)
                otherBonhomme.localCoord = myLocalCoord + new Vector2(1,0);
            else if (otherCollider.transform.position.x <= myCollider.transform.position.x - imgSize)
                otherBonhomme.localCoord = myLocalCoord + new Vector2(-1,0);

            if (otherCollider.transform.position.y > myCollider.transform.position.y + imgSize)
                otherBonhomme.localCoord = myLocalCoord + new Vector2(0,1);
            else if (otherCollider.transform.position.y <= myCollider.transform.position.y - imgSize)
                otherBonhomme.localCoord = myLocalCoord + new Vector2(0,-1);

            collision.transform.SetParent(transform);
            otherCollider.transform.localPosition = new Vector3(
                otherBonhomme.localCoord.x * imgSize/2,
                otherBonhomme.localCoord.y * imgSize/2,
                0
            );
        }
    }


    void Start()
    {
        
    }
    void Update()
    {   
        if (Input.GetKey(d)) transform.position += new Vector3 (speed*Time.deltaTime, 0, 0);
        if (Input.GetKey(q)) transform.position += new Vector3 (-speed*Time.deltaTime, 0, 0);
    }
}
