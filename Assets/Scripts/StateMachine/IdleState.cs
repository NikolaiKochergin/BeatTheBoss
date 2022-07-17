public class IdleState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _uI;

    public IdleState(UI uI, Player player, Boss boss)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _uI.MainMenu.Show();
        _player.StopMove();
        _player.PlayerAnimator.ShowIdle();
        _player.UIWidgetRageBar.Hide();
        _boss.StopMove();
        _boss.BossAnimator.ShowIdle();
    }

    public void Exit()
    {
        _uI.MainMenu.Hide();
    }
}