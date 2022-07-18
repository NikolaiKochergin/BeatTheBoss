using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private AnimationCurve _yCurve;
    [SerializeField] private float _moveDuration;

    private Transform _targetTransform;

    private void Awake()
    {
        _targetTransform = null;
    }

    private void Update()
    {
        if (_targetTransform != null)
            transform.position = _targetTransform.position;
    }

    public void Initialization(Transform transform)
    {
        _targetTransform = transform;
    }

    public void Drop(Vector3 targetPoint)
    {
        _targetTransform = null;
        StartCoroutine(MoveTo(targetPoint));
    }

    private IEnumerator MoveTo(Vector3 target)
    {
        var startPoint = transform.position;

        for (float time = 0; time < 1; time += Time.deltaTime / _moveDuration)
        {
            transform.position = Vector3.Lerp(startPoint, target, time)+ new Vector3(0,_yCurve.Evaluate(time),0);

            yield return null;
        }
        
        Destroy(gameObject);
    }
}