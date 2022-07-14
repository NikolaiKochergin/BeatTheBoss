using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private UIWidgetRageBar _rageBar;
    [SerializeField] private PlayerConfig _playerConfig;

    private Parameter _rage;

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