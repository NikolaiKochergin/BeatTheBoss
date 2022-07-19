using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponentInParent<Item>();
        var trap = other.GetComponentInParent<Trap>();
        var gate = other.GetComponentInParent<Gate>();
        var finisher = other.GetComponentInParent<Finisher>();

        if (item)
        {
            ItemTaken?.Invoke(item);
            item.Disable();
        }

        if (trap)
        {
            trap.Disable();
            TrapTaken?.Invoke(trap);
        }

        if (gate)
        {
            gate.Disable();
            GateTaken?.Invoke();
        }

        if (finisher)
        {
            finisher.DisableTrigger();
            FinisherTaken?.Invoke();
        }
    }

    public event Action<Item> ItemTaken;
    public event Action<Trap> TrapTaken;
    public event Action GateTaken;
    public event Action FinisherTaken;
}