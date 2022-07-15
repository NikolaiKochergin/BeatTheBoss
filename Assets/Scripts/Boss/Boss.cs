using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossAnimator _bossAnimator;
    [SerializeField] private BossHittedView _bossHittedView;

    public BossAnimator BossAnimator => _bossAnimator;
    public BossHittedView BossHittedView => _bossHittedView;
}