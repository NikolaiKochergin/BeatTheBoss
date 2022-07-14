using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 1)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] [Min(0)] private int _defaultRage;
    [SerializeField] [Min(0)] private int _maxRage = 100;

    public int DefaultRage => _defaultRage;
    public int MaxRage => _maxRage;
}