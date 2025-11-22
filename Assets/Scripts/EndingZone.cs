using UnityEngine;

public class EndingZone : MonoBehaviour
{
    public static EndingZone Singleton {  get; private set; }

    public int partsAmount = 0;
    public int partsCompleted = 0;

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
    }

    // Update is called once per frame
    public void CheckEnding()
    {
        switch (_endType)
        {
            case EndType.Normal:
                if (partsAmount <= partsCompleted && PlayerMovement.playerAmount == partsAmount)
                    Debug.Log("gagné!");
                break;
            case EndType.CollectAmount:
                if (PlayerMovement.playerAmount >= _collectAmount)
                    Debug.Log("GIT GUD");
                break;
        }
    }
}
