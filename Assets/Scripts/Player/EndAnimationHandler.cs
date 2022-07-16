using System;
using UnityEngine;

public class EndAnimationHandler : MonoBehaviour
{
    // Used in throw end animation
    private void Handler_ThrowEnded()
    {
        ThrowEnded?.Invoke();
    }
    
    // Used in prepare throw animation
    private void Handler_ThrowPrepareEnded()
    {
        ThrowPrepareEnded?.Invoke();
    }

    public event Action ThrowEnded;
    public event Action ThrowPrepareEnded;
}