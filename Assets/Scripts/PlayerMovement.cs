using System.Collections.Generic;
using UnityEngine;

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

    private bool _jumpKeyPressed;

    public bool ShouldSnapToGlue => Time.time - _lastUnsnapTime > 0.2f;

    private float _lastUnsnapTime = 0f;

    private bool _glued;

    [SerializeField]
    private Jump _jump;

    public float velocityMax = 1;

    private void Awake()
    {
        Singleton = this;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("bonhomme")){
            Collider2D otherCollider = transform.GetChild(0).GetComponent<Collider2D>();
            float distMin = Vector2.Distance(otherCollider.transform.position, collider.transform.position);
            for(int i = 1; i < transform.childCount; i++)
            {
                Collider2D col = transform.GetChild(i).GetComponent<Collider2D>();
                // Debug.Log($"{col.gameObject.name} -> {collider.gameObject.name}");
                // On calcule la distance entre ce collider et celui qui entre
                float dist = Vector2.Distance(col.transform.position, collider.transform.position);
                // Debug.Log(dist);
                // Si ils sont en contact (isOverlapped = true)
                if (dist < distMin)
                    otherCollider = col;
            }
            Bonhomme myBonhomme = otherCollider.GetComponent<Bonhomme>();
            Bonhomme otherBonhomme = collider.GetComponent<Bonhomme>();
            
            if (otherBonhomme == null) return;

            // POSITIONS MONDE AVANT DE TOUCHER AU PARENT
            Vector3 myPos = otherCollider.transform.position;
            Vector3 otherPos = collider.transform.position;

            Vector2 newCoord = myBonhomme.localCoord;

            float offset = imgSize / 4f;

            // ---- DÉTECTION DIRECTION ----
            float deltaX = otherPos.x - myPos.x;
            float deltaY = otherPos.y - myPos.y;

            // Debug.Log($"X:{deltaX} Y:{deltaY}");

            if (deltaY != 0 && Mathf.Abs(deltaX) < Mathf.Abs(deltaY))
                newCoord += Vector2.up * deltaY/Mathf.Abs(deltaY);
            else if (deltaX != 0)
                newCoord += Vector2.right * deltaX/Mathf.Abs(deltaX);
            else return;
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
                Transform otherT = collider.transform;
                otherT.SetParent(transform);
                playerAmount ++;
                otherBonhomme.localCoord = newCoord;
                listCoords.Add(newCoord);
                // ---- PLACEMENT ----
                otherT.localPosition = new Vector3(
                    newCoord.x * 2* offset,
                    newCoord.y * 2* offset,
                    0
                );
                AudioPlayerScript.Singleton.PlaySound(AudioPlayerScript.SoundType.Snap);
            }
        }
    }

    void Start()
    {
        AudioPlayerScript.Singleton.PlaySound(AudioPlayerScript.SoundType.Entry);
        
        listCoords.Add(new Vector2(0,0));
    }

    void MoveLeft()
    {
        if (Mathf.Abs(rb.linearVelocity.x) < velocityMax)
            rb.AddForce(Vector2.left * speed);
    }

    void MoveRight()
    {
        if (Mathf.Abs(rb.linearVelocity.x) < velocityMax)
            rb.AddForce(Vector2.right * speed);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _jumpKeyPressed = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(d))
            MoveRight();

        if (Input.GetKey(q))
            MoveLeft();

        // if (Input.GetKey(d)) rb.linearVelocity = new Vector3(rb.linearVelocity.x + velocityMax, rb.linearVelocity.y, 0);
        // if (Input.GetKey(q)) rb.linearVelocity = new Vector3(rb.linearVelocity.x - velocityMax, rb.linearVelocity.y, 0);
        // if (Input.GetKeyUp(d)) rb.linearVelocity = new Vector3(rb.linearVelocity.x + velocityMax, rb.linearVelocity.y, 0);
        // if (Input.GetKeyUp(q)) rb.linearVelocity = new Vector3(rb.linearVelocity.x - velocityMax, rb.linearVelocity.y, 0);
        if (_jump.IsGrounded())
        {
            if (_jumpKeyPressed)
                _jump.Jumping();

            AudioPlayerScript.Singleton.WalkSoundPlaying = rb.linearVelocity.sqrMagnitude > 0.3f;
        }
        
        if (_jumpKeyPressed)
            UnsnapFromRoof();

        if (Input.GetKeyUp(d) || Input.GetKeyUp(q))
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);

        _jumpKeyPressed = false;
    }

    public void SnapToRoof()
    {
        if (_glued)
            return;

        rb.gravityScale = 0;
        _glued = true;
    }

    public void UnsnapFromRoof()
    {
        if (!_glued)
            return;

        _glued = false;
        rb.gravityScale = 1;
        _lastUnsnapTime = Time.time;
    }

    private void OnDestroy()
    {
        AudioPlayerScript.Singleton.WalkSoundPlaying = false;
    }
}