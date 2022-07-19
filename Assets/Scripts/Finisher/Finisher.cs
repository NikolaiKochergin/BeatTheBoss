using UnityEngine;

public class Finisher : MonoBehaviour
{
    [SerializeField] private FinisherTrigger _finisherTrigger;

    public void DisableTrigger()
    {
        _finisherTrigger.Disable();
    }
}