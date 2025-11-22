using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    public static int playerAmount = 1;
    public List<Vector2> listCoords = new List<Vector2>();
    public float speed;
    public float imgSize;
    public KeyCode d = KeyCode.D;
    public KeyCode q = KeyCode.Q;
    public float jumpCoolDown;
    public float lastTimeJump;


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
                if (deltaX > deltaY)
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

            // ---- ATTACH ----
            Transform otherT = collision.collider.transform;
            otherT.SetParent(transform);
            
            Debug.Log($"{newCoord} !!!!!!!!!!!!!!!");

            if (! listCoords.Contains(newCoord))
            {
                playerAmount ++;
                otherBonhomme.localCoord = newCoord;
                listCoords.Add(newCoord);
            }

            // ---- PLACEMENT ----
            otherT.localPosition = new Vector3(
                newCoord.x * 2* offset,
                newCoord.y * 2* offset,
                0
            );
        }
    }

    void Start()
    {
        listCoords.Add(new Vector2(0,0));
    }

    void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

    }

    void MoveRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(d)) MoveRight();
        if (Input.GetKey(q)) MoveLeft();
        if (Time.time - lastTimeJump > jumpCoolDown && Input.GetKey(GetComponent<Jump>().space)){
            lastTimeJump = Time.time;
            GetComponent<Jump>().Jumping();
        }
    }
}
