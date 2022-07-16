using UnityEngine;

namespace RunnerMovementSystem.Examples
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField] private MovementSystem _roadMovement;
        [SerializeField] private float _sensitivity = 0.01f;

        private Vector3 _mousePosition;
        private float _saveOffset;
        private Vector3 _lastFrameMousePosition;

        public bool IsMoved { get; private set; }
        public float TurnValue { get; private set; }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _saveOffset = _roadMovement.Offset;
                _mousePosition = Input.mousePosition;
                IsMoved = true;

                _lastFrameMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                var offset = Input.mousePosition - _mousePosition;
                _roadMovement.SetOffset(_saveOffset + offset.x * _sensitivity / Screen.width);

                TurnValue = (Input.mousePosition.x - _lastFrameMousePosition.x) * Time.deltaTime / Screen.width;

                _lastFrameMousePosition = Input.mousePosition;
            }

            _roadMovement.MoveForward();

            if (Input.GetMouseButtonUp(0))
            {
                IsMoved = false;
                TurnValue = 0;
            }
        }

        private void OnEnable()
        {
            _roadMovement.PathChanged += OnPathChanged;
        }

        private void OnDisable()
        {
            _roadMovement.PathChanged -= OnPathChanged;
        }

        private void OnPathChanged(PathSegment _)
        {
            _saveOffset = _roadMovement.Offset;
            _mousePosition = Input.mousePosition;
        }
    }
}