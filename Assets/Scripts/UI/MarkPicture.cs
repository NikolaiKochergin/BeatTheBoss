using UnityEngine;

public class MarkPicture : MonoBehaviour
{
    private ThrowInput _throwInput;

    private void OnEnable()
    {
        if (_throwInput != null)
            _throwInput.MarkOffsetChanged += OnMarkOffsetChanged;
    }

    private void OnDisable()
    {
        if (_throwInput != null)
            _throwInput.MarkOffsetChanged -= OnMarkOffsetChanged;
    }

    public void Initialize(ThrowInput throwInput)
    {
        _throwInput = throwInput;
        _throwInput.MarkOffsetChanged += OnMarkOffsetChanged;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnMarkOffsetChanged(Vector3 offset)
    {
        var markPositionX = Mathf.Clamp(transform.position.x + offset.x, 0, Screen.width);
        var markPositionY = Mathf.Clamp(transform.position.y + offset.y, 0, Screen.height);

        Debug.Log("Тут нужно дописать правлиьное расположение мишени и разобраться почему не работает правильно");
    }
}