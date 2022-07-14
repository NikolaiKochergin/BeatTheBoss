using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MouseInput _mouseInput;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private UIWidgetRageBar _rageBar;
    [SerializeField] private PlayerConfig _playerConfig;

    private Parameter _rage;

    public MouseInput MouseInput => _mouseInput;
    public MovementSystem MovementSystem => _movementSystem;
    public CollisionHandler CollisionHandler => _collisionHandler;

    private void Awake()
    {
        _rage = new Parameter(_playerConfig.DefaultRage);
        _rageBar.Initialize(_rage, _playerConfig.MaxRage);
    }

    private void OnEnable()
    {
        _collisionHandler.ItemTaken += OnItemTaken;
    }

    private void OnDisable()
    {
        _collisionHandler.ItemTaken -= OnItemTaken;
    }

    private void OnItemTaken(Item item)
    {
        _rage.Set(_rage.Value + item.RageValue);
    }
}