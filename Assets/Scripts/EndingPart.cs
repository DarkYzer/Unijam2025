using UnityEngine;

public class EndingPart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Bonhomme bonhomme;
        // other.gameObject.TryGetComponent<Bonhomme>(out bonhomme);
        // bonhomme.counter++;
        // counter ++;
        // if(bonhomme.counter == 1 && counter == 1) EndingZone.partsCompleted++;
        // EndingZone.Singleton.CheckEnding();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Bonhomme bonhomme;
        // other.gameObject.TryGetComponent<Bonhomme>(out bonhomme);
        // bonhomme.counter--;
        // counter--;
        // if(bonhomme.counter == 0 && counter == 0) EndingZone.partsCompleted--;
        // EndingZone.Singleton.CheckEnding();
    }
}
