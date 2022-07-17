using System;
using UnityEngine;

public class ThrowInput : MonoBehaviour
{
    private Vector3 _clickPosition;
    private Vector3 _markOffset;

    public event Action<Vector3> MarkOffsetChanged;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _clickPosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            _markOffset = Input.mousePosition - _clickPosition;
            MarkOffsetChanged?.Invoke(_markOffset);
        }
        
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