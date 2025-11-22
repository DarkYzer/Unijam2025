using UnityEngine;

public class Jump : MonoBehaviour
{
    private float imgSize;
    public float jumpForce;
    public LayerMask PlatformLayerMask;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        imgSize = GetComponent<PlayerMovement>().imgSize;
        rb = GetComponent<Rigidbody2D>();
    }



    public bool IsGroundedChild(Collider2D col)
    {
        RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + 0.1f, PlatformLayerMask);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsGrounded()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (IsGroundedChild(child.GetComponent<Collider2D>()))
                return true;
        }
        return false;
    }
    public void Jumping()
    {
        rb.AddForce(new Vector2(0, jumpForce + imgSize/2), ForceMode2D.Impulse);
    }
}
