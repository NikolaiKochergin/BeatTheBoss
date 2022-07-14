using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponentInParent<Item>();
        var trap = other.GetComponentInParent<Trap>();

        if (item)
        {
            ItemTaken?.Invoke(item);
            item.Disable();
        }

        if (trap)
            TrapTaken?.Invoke(trap);
    }

    public event Action<Item> ItemTaken;
    public event Action<Trap> TrapTaken;
}