using UnityEngine;

public class BossHittedView : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _bodyMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer _clothMeshRenderer;

    public void SetHitted(float value)
    {
        value = Mathf.Clamp(value, 0, 100);

        _bodyMeshRenderer.SetBlendShapeWeight(0, value);
        _clothMeshRenderer.SetBlendShapeWeight(0, value);
    }
}