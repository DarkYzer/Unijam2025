using UnityEngine;

public class RoofClimb : MonoBehaviour
{
    private int itemsUsing = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!PlayerMovement.Singleton.ShouldSnapToGlue)
            return;

        itemsUsing++;
        PlayerMovement.Singleton.SnapToRoof();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        itemsUsing--;
        if (itemsUsing == 0)
            PlayerMovement.Singleton.UnsnapFromRoof();
    }
}
