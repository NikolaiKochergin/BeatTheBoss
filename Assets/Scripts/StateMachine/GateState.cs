public class GateState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private UI _ui;

    public GateState(UI ui, Player player, Boss boss)
    {
        _ui = ui;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _player.StopMove();
        _player.PlayerAnimator.ThrowPrepareEnded += OnThrowPrepareEnded;
        _player.PlayerAnimator.ShowThrowStart();
        _boss.StopMove();
        _boss.BossAnimator.ShowTerrified();
    }

    public void Exit()
    {
        _player.PlayerAnimator.ThrowPrepareEnded -= OnThrowPrepareEnded;
        _player.ThrowInput.Throw -= OnThrowStarted;
        _player.ThrowInput.Disable();
    }

    private void OnThrowPrepareEnded()
    {
        _player.ThrowInput.Enable();
        _player.ThrowInput.Throw += OnThrowStarted;
    }

    private void OnThrowStarted()
    {
        _player.PlayerAnimator.ShowThrowEnd();
    }
}