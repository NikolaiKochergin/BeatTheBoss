using UnityEngine;

public class UIWidgetRageBar : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    private int _maxValue;

    private Parameter _parameter;

    private void OnEnable()
    {
        if (_parameter != null)
        {
            _parameter.Changed += OnParameterChanged;
            OnParameterChanged(_parameter.Value);
        }
    }

    private void OnDisable()
    {
        if (_parameter != null)
        {
            _parameter.Changed -= OnParameterChanged;
            OnParameterChanged(_parameter.Value);
        }
    }

    public void Initialize(Parameter parameter, int maxValue)
    {
        _parameter = parameter;
        _maxValue = maxValue;
    }

    private void OnParameterChanged(int value)
    {
        var normalizeValue = (float) value / _maxValue;
        _progressBar.SetValue(normalizeValue);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}