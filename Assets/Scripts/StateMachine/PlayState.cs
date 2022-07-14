public class PlayState : IState
{
    private readonly Player _player;
    private readonly UI _uI;

    public PlayState(UI uI, Player player)
    {
        _uI = uI;
        _player = player;
    }

    public void Enter()
    {
        _uI.PlayMenu.Show();
        _player.StartMove();
        _player.PlayerAnimator.ShowRun();
    }

    public void Exit()
    {
        _uI.PlayMenu.Hide();
    }
}