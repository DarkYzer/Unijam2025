using UnityEngine;

public class EndingZone : MonoBehaviour
{
    public static int partsAmount = 0;
    public static int partsCompleted = 0;
    public float offset = .5f;
    public GameObject player;

    bool HasWin()
    {
        Transform child; bool temp; Transform playerChild;
        for ( int i = 0; i < transform.childCount; i++)
        {
            child = transform.GetChild(i);
            temp = false;
            for (int j = 0; j < player.transform.childCount; j++)
            {
                playerChild = player.transform.GetChild(j);
                if (Vector2.Distance(child.position, playerChild.position) < offset)
                    temp = true;
            }
            if (temp == false)
                return false;
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        // if(partsAmount <= partsCompleted && PlayerMovement.playerAmount == partsAmount) Debug.Log("gagné!");
        if (HasWin())
            Debug.Log("gagné !!!!!!!!");
    }
}
