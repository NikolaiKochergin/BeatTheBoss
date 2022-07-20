public class FinisherState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _uI;

    public FinisherState(UI uI, Player player, Boss boss)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _uI.FinisherMenu.Show();
        _player.UIWidgetRageBar.Hide();
        _player.PlayerAnimator.ShowIdle();
    }

    public void Exit()
    {
        _uI.FinisherMenu.Hide();
    }
}