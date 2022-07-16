using System;
using UnityEngine;

public class ThrowInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Throw?.Invoke();
    }
    public event Action Throw;

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}