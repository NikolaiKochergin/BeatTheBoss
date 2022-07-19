public class PlayState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _uI;

    public PlayState(UI uI, Player player, Boss boss)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _uI.PlayMenu.Show();
        _player.UIWidgetRageBar.Show();
        _player.StartMove();
        _player.PlayerAnimator.ShowRun();
        _boss.StarMove();
        _boss.BossAnimator.ShowRun();
    }

    public void Exit()
    {
        _player.StopMove();
        //_boss.StopMove();
        _uI.PlayMenu.Hide();
    }
}