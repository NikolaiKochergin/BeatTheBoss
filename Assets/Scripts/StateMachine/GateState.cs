public class GateState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private UI _ui;
    private MainCameraAnimator _mainCameraAnimator;

    public GateState(UI ui, Player player, Boss boss, MainCameraAnimator mainCameraAnimator)
    {
        _ui = ui;
        _player = player;
        _boss = boss;
        _mainCameraAnimator = mainCameraAnimator;
    }

    public void Enter()
    {
        _ui.GateMenu.MarkPicture.Initialize(_player.ThrowInput);
        _ui.GateMenu.Show();
        _player.StopMove();
        _player.UIWidgetRageBar.Hide();
        _player.PlayerAnimator.ShowThrowPrepare(()=>
        {
            _player.ThrowInput.Enable();
            _ui.GateMenu.MarkPicture.Show();
        });
        _player.ThrowInput.Throw += OnThrowStarted;
        _boss.StopMove();
        _boss.BossAnimator.ShowTerrified();
        _mainCameraAnimator.ShowThrowViewIn();
    }

    public void Exit()
    {
        _ui.GateMenu.Hide();
        _player.ThrowInput.Throw -= OnThrowStarted;
        _player.ThrowInput.Disable();
        _mainCameraAnimator.ShowThrowViewOut();
    }

    private void OnThrowStarted()
    {
        _ui.GateMenu.MarkPicture.Hide();
        _player.PlayerAnimator.ShowThrowEnd();
    }
}