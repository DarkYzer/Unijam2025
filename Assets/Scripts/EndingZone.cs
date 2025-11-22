using UnityEngine;

public class EndingZone : MonoBehaviour
{
    public static int partsAmount = 0;
    public static int partsCompleted = 0;

    // Update is called once per frame
    void Update()
    {
        if(partsAmount <= partsCompleted && PlayerMovement.playerAmount == partsAmount) Debug.Log("gagné!");
    }
}
