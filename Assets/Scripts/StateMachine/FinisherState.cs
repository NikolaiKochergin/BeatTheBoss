public class FinisherState : IState
{
    private readonly Player _player;
    private readonly UI _uI;

    public FinisherState(UI uI, Player player)
    {
        _uI = uI;
        _player = player;
    }

    public void Enter()
    {
        _uI.FinisherMenu.Show();
    }

    public void Exit()
    {
        _uI.FinisherMenu.Hide();
    }
}