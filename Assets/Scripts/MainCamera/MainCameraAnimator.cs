using System;
using UnityEngine;

public class MainCameraAnimator : MonoBehaviour
{
    private const string ThrowViewIn = nameof(ThrowViewIn);
    private const string ThrowViewOut = nameof(ThrowViewOut);
    
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Disable();
    }

    public void Enable()
    {
        _animator.enabled = true;
    }

    public void Disable()
    {
        _animator.enabled = false;
    }
    
    public void ShowThrowViewIn()
    {
        Enable();
    }

    public void ShowThrowViewOut()
    {
        _animator.Play(ThrowViewOut);
    }
}