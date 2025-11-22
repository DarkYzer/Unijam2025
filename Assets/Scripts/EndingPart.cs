using UnityEngine;

public class EndingPart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        EndingZone.partsAmount++;
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        EndingZone.partsCompleted++;
    }

    void OnTriggerExit()
    {
        EndingZone.partsCompleted--;
    }
}
