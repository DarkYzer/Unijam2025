using UnityEngine;

public class EndingPart : MonoBehaviour
{
    void Start()
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
