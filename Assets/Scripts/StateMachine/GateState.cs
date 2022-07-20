public class GateState : IState
{
    private readonly Boss _boss;
    private readonly MainCameraAnimator _mainCameraAnimator;
    private readonly Player _player;
    private readonly UI _ui;

    public GateState(UI ui, Player player, Boss boss, MainCameraAnimator mainCameraAnimator)
    {
        _ui = ui;
        _player = player;
        _boss = boss;
        _mainCameraAnimator = mainCameraAnimator;
    }

    public void Enter()
    {
        _ui.GateMenu.Show();
        _player.StartMove();
        _player.UIWidgetRageBar.Hide();
        _player.PlayerAnimator.ShowThrowPrepare(_player.ThrowInput.Enable);
        _player.ThrowInput.Throw += OnThrowStarted;

        _player.SetTimeScale(0.1f);
        _boss.SetTimeScale(0.1f);
        _mainCameraAnimator.ShowThrowViewIn();
    }

    public void Exit()
    {
        _ui.GateMenu.Hide();
        _player.ThrowInput.Throw -= OnThrowStarted;
        _player.ThrowInput.Disable();
        _mainCameraAnimator.ShowThrowViewOut();

        _player.SetTimeScale(1f);
        _boss.SetTimeScale(1f);
    }

    private void OnThrowStarted()
    {
        _player.PlayerAnimator.ShowThrowEnd();
    }
}