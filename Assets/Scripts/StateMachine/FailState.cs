public class FailState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _ui;

    public FailState(UI uI, Player player, Boss boss)
    {
        _ui = uI;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _ui.FailMenu.Show();
    }

    public void Exit()
    {
        _ui.FailMenu.Hide();
    }
}