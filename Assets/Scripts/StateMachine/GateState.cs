using UnityEngine;

public class GateState : IState
{
    private readonly Boss _boss;
    private readonly Player _player;
    private readonly MainCameraAnimator _mainCameraAnimator;
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
        _player.UIWidgetRageBar.Hide();
        _player.PlayerAnimator.ShowThrowPrepare(_player.ThrowInput.Enable);
        _player.ThrowInput.Throw += OnThrowStarted;
        
        _boss.BossAnimator.SetTimeScale(0.1f);
        _boss.SetSpeedScale(0.1f);
        //_boss.BossAnimator.ShowTerrified();
        _mainCameraAnimator.ShowThrowViewIn();
    }

    public void Exit()
    {
        _ui.GateMenu.Hide();
        _player.ThrowInput.Throw -= OnThrowStarted;
        _player.ThrowInput.Disable();
        _mainCameraAnimator.ShowThrowViewOut();
        
        _boss.BossAnimator.SetTimeScale(1f);
        _boss.SetSpeedScale(1f);
    }

    private void OnThrowStarted()
    {
        _player.PlayerAnimator.ShowThrowEnd();
    }
}