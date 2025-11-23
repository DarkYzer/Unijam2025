using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public LayerMask PlatformLayerMask;
    public bool IsGroundedChild(Collider2D col)
    {
        RaycastHit2D hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, 0.1f, PlatformLayerMask);
        
        return hit;
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
        PlayerMovement.Singleton.rb.AddForce(new Vector2(0, jumpForce + PlayerMovement.Singleton.imgSize / 2), ForceMode2D.Impulse);
        PlayerMovement.Singleton.rb.gravityScale = 1;
    }
}
