using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private BossAnimator _bossAnimator;
    [SerializeField] private Rigidbody[] _allRigidbodies;

    private void Awake()
    {
        foreach (var rigidbody in _allRigidbodies) rigidbody.isKinematic = true;
    }

    public void MakePhysical()
    {
        _bossAnimator.Disable();
        foreach (var rigidbody in _allRigidbodies) rigidbody.isKinematic = false;
    }
}