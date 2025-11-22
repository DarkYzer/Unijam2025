using UnityEngine;

public class RoofClimb : MonoBehaviour
{
    private int itemsUsing = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb;
        itemsUsing++;
        if(other.gameObject.transform.parent.gameObject.TryGetComponent<Rigidbody2D>(out rb))
        {
            rb.gravityScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb;
        itemsUsing--;
        if(other.gameObject.transform.parent.gameObject.TryGetComponent<Rigidbody2D>(out rb) && itemsUsing == 0)
        {
            rb.gravityScale = 1;
        }
    }
}
