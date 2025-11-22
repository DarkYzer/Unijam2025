using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Singleton { get; private set; }
    public static int playerAmount = 1;
    public List<Vector2> listCoords = new List<Vector2>();
    public float speed;
    public float imgSize;
    public KeyCode d = KeyCode.D;
    public KeyCode q = KeyCode.Q;
    public Rigidbody2D rb;

    public float velocityMax = 1;

    private void Awake()
    {
        Singleton = this;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Bonhomme myBonhomme = collision.otherCollider.GetComponent<Bonhomme>();
        Bonhomme otherBonhomme = collision.collider.GetComponent<Bonhomme>();
        
        if (Vector3.Distance(collision.otherCollider.transform.position, collision.collider.transform.position) < imgSize/1.5f)
        {
            if (otherBonhomme == null) return;

            // POSITIONS MONDE AVANT DE TOUCHER AU PARENT
            Vector3 myPos = collision.otherCollider.transform.position;
            Vector3 otherPos = collision.collider.transform.position;

            Vector2 newCoord = myBonhomme.localCoord;

            float offset = imgSize / 4f;

            // ---- DÉTECTION DIRECTION ----
            float deltaX = otherPos.x - myPos.x;
            float deltaY = otherPos.y - myPos.y;

            Debug.Log($"X:{deltaX} Y:{deltaY}");

            if (deltaX != 0 && deltaY != 0){
                if (Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
                    newCoord += Vector2.up * deltaY/Mathf.Abs(deltaY);
                else
                    newCoord += Vector2.right * deltaX/Mathf.Abs(deltaX);
            } else return;
            //if (otherPos.y > myPos.y + offset)
            //    newCoord += Vector2.up;
            //else if (otherPos.y < myPos.y - offset)
            //    newCoord += Vector2.down;
            //else if (otherPos.x > myPos.x + offset)
            //    newCoord += Vector2.right;
            //else if (otherPos.x < myPos.x - offset)
            //    newCoord += Vector2.left;

            if (! listCoords.Contains(newCoord))
            {
                // ---- ATTACH ----
                Transform otherT = collision.collider.transform;
                playerAmount ++;
                // ---- PLACEMENT ----
                // Transform localPositionBackup = otherT.localPosition;

                otherT.localPosition = new Vector3(
                    newCoord.x * 2* offset,
                    newCoord.y * 2* offset,
                    0
                );
                
                // if ()

                otherBonhomme.localCoord = newCoord;
                listCoords.Add(newCoord);
                otherT.SetParent(transform);
            }

            
        }
    }

    void Start()
    {
        listCoords.Add(new Vector2(0,0));
    }

    void MoveLeft()
    {
        if (rb.linearVelocity.magnitude < velocityMax)
            rb.AddForce(Vector2.left * speed);
    }

    void MoveRight()
    {
        if (rb.linearVelocity.magnitude < velocityMax)
            rb.AddForce(Vector2.right * speed);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(d)) MoveRight();
        if (Input.GetKey(q)) MoveLeft();
        // if (Input.GetKey(d)) rb.linearVelocity = new Vector3(rb.linearVelocity.x + velocityMax, rb.linearVelocity.y, 0);
        // if (Input.GetKey(q)) rb.linearVelocity = new Vector3(rb.linearVelocity.x - velocityMax, rb.linearVelocity.y, 0);
        // if (Input.GetKeyUp(d)) rb.linearVelocity = new Vector3(rb.linearVelocity.x + velocityMax, rb.linearVelocity.y, 0);
        // if (Input.GetKeyUp(q)) rb.linearVelocity = new Vector3(rb.linearVelocity.x - velocityMax, rb.linearVelocity.y, 0);
        if (GetComponent<Jump>().IsGrounded() && Input.GetKey(KeyCode.Space)){
            GetComponent<Jump>().Jumping();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.gravityScale = 1;
        }

        if (Input.GetKeyUp(d) || Input.GetKeyUp(q)) rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
    }
}