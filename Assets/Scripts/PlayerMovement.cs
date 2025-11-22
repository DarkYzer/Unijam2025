using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement: MonoBehaviour{

    public static int playerAmount;
    public float speed;   
    public float imgSize;
    public Vector3 deplacement;
    public KeyCode d = KeyCode.D;
    public KeyCode q = KeyCode.Q;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Bonhomme myBonhomme = collision.otherCollider.GetComponent<Bonhomme>();
        Bonhomme otherBonhomme = collision.collider.GetComponent<Bonhomme>();

        if (otherBonhomme == null) return;

        Vector2 myLocalCoord = myBonhomme.localCoord;
        Vector2 newCoord = myLocalCoord;

        Vector3 myPos = collision.otherCollider.transform.position;
        Vector3 otherPos = collision.collider.transform.position;

        if (otherPos.x > myPos.x) newCoord += new Vector2(1, 0);
        else if (otherPos.x < myPos.x) newCoord += new Vector2(-1, 0);

        else if (otherPos.y > myPos.y) newCoord += new Vector2(0, 1);
        else if (otherPos.y < myPos.y) newCoord += new Vector2(0, -1);

        Debug.Log($"{otherPos.x > myPos.x + imgSize}, {otherPos.x < myPos.x - imgSize}, {otherPos.y > myPos.y + imgSize}, {otherPos.y < myPos.y - imgSize}");
        Debug.Log($"other: {otherPos}, my : {myPos}");
        Debug.Log($"me: {collision.otherCollider.name}, other : {collision.collider.name}");
        Transform otherTransform = collision.collider.transform;
        otherTransform.SetParent(transform);
        otherBonhomme.localCoord = newCoord;

        otherTransform.localPosition = new Vector3(
            newCoord.x * imgSize / 2f,
            newCoord.y * imgSize / 2f,
            0
        );

        Debug.Log("localCoord modifié =" + otherBonhomme.localCoord);
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
