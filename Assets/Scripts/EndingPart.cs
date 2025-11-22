using UnityEngine;

public class EndingPart : MonoBehaviour
{
    private int counter = 0;
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
        counter ++;
        if(bonhomme.counter == 1 && counter == 1) EndingZone.partsCompleted++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Bonhomme bonhomme;
        other.gameObject.TryGetComponent<Bonhomme>(out bonhomme);
        bonhomme.counter--;
        counter--;
        if(bonhomme.counter == 0 && counter == 0) EndingZone.partsCompleted--;
    }
}
