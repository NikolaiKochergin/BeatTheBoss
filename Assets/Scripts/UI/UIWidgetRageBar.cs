using UnityEngine;

public class UIWidgetRageBar : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    private int _maxValue;

    private Parameter _parameter;

    private void OnEnable()
    {
        if (_parameter != null)
            _parameter.Changed += OnParameterChanged;
    }

    private void OnDisable()
    {
        if (_parameter != null)
            _parameter.Changed -= OnParameterChanged;
    }

    public void Initialize(Parameter parameter, int maxValue)
    {
        _parameter = parameter;
        _maxValue = maxValue;
        OnParameterChanged(_parameter.Value);
        if (_parameter != null)
            _parameter.Changed += OnParameterChanged;
    }

    private void OnParameterChanged(int value)
    {
        var normalizeValue = (float) value / _maxValue;
        _progressBar.SetValue(normalizeValue);
    }
}