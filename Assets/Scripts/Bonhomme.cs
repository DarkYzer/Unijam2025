using UnityEngine;

public class Bonhomme: MonoBehaviour
{
    public Vector2 localCoord = new Vector2(0,0);

    public bool IsConnected => transform.parent != null;

    public int counter = 0;

}