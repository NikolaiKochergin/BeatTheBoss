public class EndLevelState : IState
{
    private readonly UI _uI;
    private readonly Player _player;

    public EndLevelState(UI uI, Player player)
    {
        _uI = uI;
        _player = player;
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