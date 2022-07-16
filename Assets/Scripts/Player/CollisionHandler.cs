using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponentInParent<Item>();
        var trap = other.GetComponentInParent<Trap>();
        var gate = other.GetComponentInParent<Gate>();

        if (item)
        {
            ItemTaken?.Invoke(item);
            item.Disable();
        }

        if (trap)
            TrapTaken?.Invoke(trap);
        
        if(gate)
            GateTaken?.Invoke();
    }

    public event Action<Item> ItemTaken;
    public event Action<Trap> TrapTaken;
    public event Action GateTaken;
}