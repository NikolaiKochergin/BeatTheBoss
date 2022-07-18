using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _imgFiller;

    public void SetValue(float valueNormalized)
    {
        _imgFiller.fillAmount = valueNormalized;
    }
}