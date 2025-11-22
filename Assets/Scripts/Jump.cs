using UnityEngine;

public class Jump : MonoBehaviour
{
    private float imgSize;
    public float jumpForce;
    public KeyCode space = KeyCode.Space;
    private Rigidbody2D rb;
    void Start()
    {
        imgSize = GetComponent<PlayerMovement>().imgSize;
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void Jumping()
    {
        if (Input.GetKeyDown(space))
	    {
		    rb.AddForce(new Vector2(0, jumpForce + imgSize/2), ForceMode2D.Impulse);
	    }
    }
}
