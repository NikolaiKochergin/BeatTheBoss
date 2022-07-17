using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private UIWidgetRageBar _rageBar;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Parameter _rage;

    public CollisionHandler CollisionHandler => _collisionHandler;
    public UIWidgetRageBar UIWidgetRageBar => _rageBar;
    public PlayerAnimator PlayerAnimator => _playerAnimator;

    private void Awake()
    {
        _rage = new Parameter(_playerConfig.DefaultRage);
        _rageBar.Initialize(_rage, _playerConfig.MaxRage);
    }

    private void OnEnable()
    {
        _collisionHandler.ItemTaken += OnItemTaken;
        _collisionHandler.TrapTaken += OnTrapTaken;
    }

    private void OnDisable()
    {
        _collisionHandler.ItemTaken -= OnItemTaken;
        _collisionHandler.TrapTaken -= OnTrapTaken;
    }

    private void OnItemTaken(Item item)
    {
        _rage.Set(_rage.Value + item.RageValue);
    }

    private void OnTrapTaken(Trap trap)
    {
        _playerAnimator.ShowStumbling();
        _rage.Add(-trap.Value);
    }
}