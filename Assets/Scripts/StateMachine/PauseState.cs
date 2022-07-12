public class PauseState : IState
{
    private UI _uI;
    private Player _player;

    public PauseState(UI uI, Player player)
    {
        _uI = uI;
        _player = player;
    }

    public void Enter()
    {
        _uI.SettingsMenu.Show();
    }

    public void Exit()
    {
        _uI.SettingsMenu.Hide();
    }
}