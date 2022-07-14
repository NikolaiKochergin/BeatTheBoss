using UnityEngine;

[SelectionBase]
public class Item : MonoBehaviour
{
    [SerializeField] [Min(0)] private int _rageValue;

    public int RageValue => _rageValue;

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}