using System;
using UnityEngine;

public class ThrowInput : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _sensitivity;
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private MainCameraAnimator _cameraAnimator;

    [SerializeField] private Grenade _grenadePrefab;
    [SerializeField] private GrenadeSpawnPoint _grenadeSpawnPoint;

    [SerializeField] private EndAnimationHandler _endAnimationHandler;

    private Vector3 _clickPosition;

    private Quaternion _defaultRotation;
    private Camera _mainCamera;

    private Ray _ray;
    private Grenade _spawnedGrenade;

    private Vector3 _grenadeTargetPoint;


    private void Awake()
    {
        _mainCamera = Camera.main;
        Disable();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickPosition = Input.mousePosition;
            _defaultRotation = _rotationPoint.transform.localRotation;
        }

        if (Input.GetMouseButton(0))
        {
            var mouseDelta = Input.mousePosition - _clickPosition;

            _rotationPoint.transform.localRotation = Quaternion.Euler(
                (_defaultRotation.y - mouseDelta.y) * _sensitivity,
                (_defaultRotation.x + mouseDelta.x) * _sensitivity,
                0);

            _ray.origin = _grenadeSpawnPoint.transform.position;
            _ray.direction = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 12)) -
                             _ray.origin;

            if (Physics.Raycast(_ray, out RaycastHit hitInfo))
            {
                var boss = hitInfo.collider.GetComponent<Boss>();
                if (boss)
                {
                    _grenadeTargetPoint = hitInfo.point;
                }
            }
                

            Debug.DrawRay(_ray.origin, _ray.direction * 12, Color.red);

            //_mainCamera.transform.RotateAround(_rotationPoint.transform.position, Vector3.up, transform.localRotation.y - mouseDelta.x / Screen.width);
            //_mainCamera.transform.RotateAround(_rotationPoint.transform.position, _mainCamera.transform.right, mouseDelta.y / Screen.height);

            //MarkOffsetChanged?.Invoke(_markOffset);
        }

        if (Input.GetMouseButtonUp(0)) Throw?.Invoke();
    }

    private void OnEnable()
    {
        _endAnimationHandler.GrenadeDropped += DropGrenade;
    }

    public event Action<Vector3> MarkOffsetChanged;
    public event Action Throw;

    public void Enable()
    {
        _mainCamera.transform.SetParent(_rotationPoint.transform);
        _spawnedGrenade = SpawnGrenade();


        enabled = true;
    }

    public void Disable()
    {
        _mainCamera.transform.SetParent(_cameraAnimator.transform);
        enabled = false;
    }

    private Grenade SpawnGrenade()
    {
        var grenade = Instantiate(_grenadePrefab);
        grenade.Initialization(_grenadeSpawnPoint.transform);

        return grenade;
    }

    private void DropGrenade()
    {
        _spawnedGrenade.Drop(_grenadeTargetPoint);
        _endAnimationHandler.GrenadeDropped -= DropGrenade;
    }
}