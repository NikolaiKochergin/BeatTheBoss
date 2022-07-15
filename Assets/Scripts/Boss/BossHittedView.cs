using UnityEngine;

public class BossHittedView : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _bodyMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer _clothMeshRenderer;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _hitedMaterial;

    public void SetHitted(float value)
    {
        value = Mathf.Clamp(value, 0, 100);

        _bodyMeshRenderer.SetBlendShapeWeight(0, value);
        _clothMeshRenderer.SetBlendShapeWeight(0, value);

        _bodyMeshRenderer.materials[0].Lerp(_defaultMaterial, _hitedMaterial, value / 100);
        _bodyMeshRenderer.UpdateGIMaterials();
    }
}