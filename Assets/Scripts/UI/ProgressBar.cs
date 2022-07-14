using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _imgFiller;

    public void SetValue(float valueNormalized)
    {
        Debug.Log("Сделать тут плавное изменение слайдера и добавить частицы");
        _imgFiller.fillAmount = valueNormalized;
    }
}