using UnityEngine;

public class EndingZone : MonoBehaviour
{
    public static int partsAmount;
    public static int partsCompleted;

    // Update is called once per frame
    void Update()
    {
        if(partsAmount == partsCompleted) Debug.Log("gagné!");
    }
}
