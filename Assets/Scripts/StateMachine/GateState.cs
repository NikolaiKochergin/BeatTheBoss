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
        _player.PlayerAnimator.ShowThrowPrepare(_player.ThrowInput.Enable);
        _player.ThrowInput.Throw += OnThrowStarted;
        _boss.StopMove();
        _boss.BossAnimator.ShowTerrified();
    }

    public void Exit()
    {
        _player.ThrowInput.Throw -= OnThrowStarted;
        _player.ThrowInput.Disable();
    }

    private void OnThrowStarted()
    {
        _player.PlayerAnimator.ShowThrowEnd();
    }
}