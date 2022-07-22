public class FinisherState : IState
{
    private readonly Boss _boss;
    private readonly MainCameraAnimator _mainCameraAnimator;
    private readonly Player _player;
    private readonly UI _uI;

    public FinisherState(UI uI, Player player, Boss boss, MainCameraAnimator mainCameraAnimator)
    {
        _uI = uI;
        _player = player;
        _boss = boss;
        _mainCameraAnimator = mainCameraAnimator;
    }

    public void Enter()
    {
        _uI.FinisherMenu.Show();
        _player.UIWidgetRageBar.Hide();
        _player.PlayerAnimator.ShowThrowPrepare(_player.ThrowInput.Enable);
        _player.ThrowInput.Throw += OnThrowStarted;
    }

    public void Exit()
    {
        _uI.FinisherMenu.Hide();
        _player.ThrowInput.Throw -= OnThrowStarted;
        _player.ThrowInput.Disable();
        _mainCameraAnimator.ShowThrowViewOut();
        
    }
    
    private void OnThrowStarted()
    {
        _player.PlayerAnimator.ShowThrowEnd();
    }
}