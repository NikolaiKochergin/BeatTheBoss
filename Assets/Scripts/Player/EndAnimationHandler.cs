using System;
using UnityEngine;

public class EndAnimationHandler : MonoBehaviour
{
    private Action ThrowEnded;

    private Action ThrowPrepareEnded;

    public event Action GrenadeDropped;

    public void WaitingForThrowPrepare(Action callback)
    {
        ThrowPrepareEnded = callback;
    }

    public void WaitingForThrowEnded(Action callback)
    {
        ThrowEnded = callback;
    }
    
    
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

    private void Handler_DropGrenade()
    {
        GrenadeDropped?.Invoke();
    }
}