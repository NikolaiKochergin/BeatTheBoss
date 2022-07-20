using UnityEngine;

public class BossAnimator : MonoBehaviour
{
    private const string Idle = nameof(Idle);
    private const string Run = nameof(Run);
    private const string Terrified = nameof(Terrified);
    private const string Finisher = nameof(Finisher);
    
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

    public void ShowFinisher()
    {
        ResetTriggers();
        _bossAnimator.SetTrigger(Finisher);
    }

    public void SetTimeScale(float value)
    {
        _bossAnimator.speed = value;
    }

    private void ResetTriggers()
    {
        _bossAnimator.ResetTrigger(Idle);
        _bossAnimator.ResetTrigger(Run);
        _bossAnimator.ResetTrigger(Terrified);
    }
}