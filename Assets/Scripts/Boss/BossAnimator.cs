using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Terrified = nameof(Terrified);
    
    [SerializeField] private Animator _bossAnimator;

    public void ShowIdle()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Idle);
    }

    public void ShowRun()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Run);
    }

    public void ShowTerrified()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Terrified);
    }

    private void ResetTriggers()
    {
        _bossAnimator.ResetTrigger(Idle);
        _bossAnimator.ResetTrigger(Run);
        _bossAnimator.ResetTrigger(Terrified);
    }
}