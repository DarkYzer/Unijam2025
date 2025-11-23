using UnityEngine;

public class EndingZone : MonoBehaviour
{
    public float offset = .5f;

    public static EndingZone Singleton { get; private set; }

    [SerializeField]
    private EndType _endType = EndType.Normal;

    [SerializeField]
    private int _collectAmount;

    private enum EndType
    {
        Normal,
        CollectAmount,
    }

    private void Awake()
    {
        Singleton = this;
        PlayerMovement.playerAmount = 1;
    }

    public void Update()
    {
        switch (_endType)
        {
            case EndType.Normal:
                if (HasWin() && PlayerMovement.playerAmount == transform.childCount)
                    Debug.Log("gagné!");
                break;
            case EndType.CollectAmount:
                if (PlayerMovement.playerAmount >= _collectAmount)
                    Debug.Log("GIT GUD");
                break;
        }
    }

    bool HasWin()
    {
        Transform child; bool temp; Transform playerChild;
        for (int i = 0; i < transform.childCount; i++)
        {
            child = transform.GetChild(i);
            temp = false;
            for (int j = 0; j < PlayerMovement.Singleton.transform.childCount; j++)
            {
                playerChild = PlayerMovement.Singleton.transform.GetChild(j);
                if (Vector2.Distance(child.position, playerChild.position) < offset)
                    temp = true;
            }
            if (temp == false)
                return false;
        }
        return true;
    }
}
