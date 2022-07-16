using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossAnimator _bossAnimator;
    [SerializeField] private BossHittedView _bossHittedView;
    [SerializeField] private BossInput _bossInput;

    public BossAnimator BossAnimator => _bossAnimator;
    public BossHittedView BossHittedView => _bossHittedView;

    public void StarMove()
    {
        _bossInput.Enable();
    }

    public void StopMove()
    {
        _bossInput.Disable();
    }
}