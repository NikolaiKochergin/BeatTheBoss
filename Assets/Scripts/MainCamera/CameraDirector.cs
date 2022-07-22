using UnityEngine;

public class CameraDirector : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _sensitivity;
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private Transform _cameraContainer;
    
    private Vector3 _tapPoint;
    private Vector3 _defaultRotation;

    private void Awake()
    {
        Disable();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tapPoint = Input.mousePosition;
            _defaultRotation = _rotationPoint.localRotation.eulerAngles;
            Debug.Log(_defaultRotation);
        }

        if (Input.GetMouseButton(0))
        {
            var mouseDelta = Input.mousePosition - _tapPoint;
            _rotationPoint.localRotation = Quaternion.Euler(
                _defaultRotation.y - mouseDelta.y * _sensitivity / Screen.height,
                _defaultRotation.x + mouseDelta.x * _sensitivity / Screen.width,
                0);
            
            Debug.Log(_rotationPoint.localRotation.eulerAngles);
        }
    }

    private void OnEnable()
    {
        Enable();
    }

    private void OnDisable()
    {
        Disable();
    }

    public void Enable()
    {
        enabled = true;
        transform.SetParent(_rotationPoint);
    }

    public void Disable()
    {
        transform.SetParent(_cameraContainer);
        enabled = false;
    }
}