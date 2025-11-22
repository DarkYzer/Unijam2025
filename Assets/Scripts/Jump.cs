using UnityEngine;

public class Jump : MonoBehaviour
{
    public float imgSize;
    public KeyCode space = KeyCode.Space;
    public Rigidbody2D rb;
    void Start()
    {
    }
    
    void Update()
    {
        if (Input.GetKeyDown(space))
	    {
		rb.AddForce(new Vector2(0, imgSize/2), ForceMode2D.Impulse);
	    }
    }
}
