using UnityEngine;

public class EndingPart : MonoBehaviour
{
    void Start()
    {
        EndingZone.partsAmount++;
        Debug.Log(EndingZone.partsAmount);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        Bonhomme bonhomme;
        other.gameObject.TryGetComponent<Bonhomme>(out bonhomme);
        bonhomme.counter++;
        if(bonhomme.counter == 1) EndingZone.partsCompleted++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Bonhomme bonhomme;
        other.gameObject.TryGetComponent<Bonhomme>(out bonhomme);
        bonhomme.counter--;
        if(bonhomme.counter == 0) EndingZone.partsCompleted--;
    }
}
