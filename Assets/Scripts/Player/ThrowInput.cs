using System;
using UnityEngine;


// Этот класс нужно зарефакторить и разложить в нормальную иерархию.
public class ThrowInput : MonoBehaviour
{
    [SerializeField] [Min(0)] private float _sensitivity;
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private MainCameraAnimator _cameraAnimator;

    [SerializeField] private Grenade _grenadePrefab;
    [SerializeField] private GrenadeSpawnPoint _grenadeSpawnPoint;

    [SerializeField] private EndAnimationHandler _endAnimationHandler;
    [SerializeField] private ParticleSystem _rayParticles;
    [SerializeField] private ParticleSystem _pointParticles;

    [SerializeField] private LayerMask _layerMask;

    private Vector3 _clickPosition;

    private Quaternion _defaultRotation;

    private Vector3 _grenadeTargetPoint;
    private Camera _mainCamera;

    private Ray _ray;
    private Grenade _spawnedGrenade;

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

            if (Physics.Raycast(_ray, out var hitInfo, 20, _layerMask))
            {
                _grenadeTargetPoint = hitInfo.point;
                _pointParticles.gameObject.SetActive(true);
                _pointParticles.Play();
                _pointParticles.transform.position = hitInfo.point;
            }
            else
            {
                _grenadeTargetPoint = _ray.GetPoint(12);
                _pointParticles.Stop();
                _pointParticles.gameObject.SetActive(false);
            }

            Debug.DrawRay(_ray.origin, _ray.direction * 12, Color.red);
            _rayParticles.transform.LookAt(_ray.GetPoint(1));
        }

        if (Input.GetMouseButtonUp(0))
        {
            _rayParticles.gameObject.SetActive(false);
            _pointParticles.gameObject.SetActive(false);
            Throw?.Invoke();
        }
    }

    private void OnEnable()
    {
        _endAnimationHandler.GrenadeDropped += DropGrenade;
    }

    public event Action Throw;

    public void Enable()
    {
        _mainCamera.transform.SetParent(_rotationPoint.transform);
        _spawnedGrenade = SpawnGrenade();
        _rayParticles.gameObject.SetActive(true);
        _rayParticles.transform.LookAt(
            _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 12)));
        _pointParticles.gameObject.SetActive(true);
        enabled = true;
    }

    public void Disable()
    {
        _mainCamera.transform.SetParent(_cameraAnimator.transform);
        _rayParticles.gameObject.SetActive(false);
        _pointParticles.gameObject.SetActive(false);
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