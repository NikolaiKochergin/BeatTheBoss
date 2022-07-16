public class EndLevelState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly UI _uI;

    public EndLevelState(UI uI, Player player, Boss boss)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
    }

    public void Enter()
    {
        _uI.EndLevelMenu.Show();
    }

    public void Exit()
    {
        _uI.EndLevelMenu.Hide();
    }
}