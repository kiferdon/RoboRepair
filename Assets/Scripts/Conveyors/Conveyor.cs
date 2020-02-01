using System;
using UnityEngine;

public class Conveyor : MonoBehaviour {
    public float distance;
    public float timeStep;
    public Transform from;
    public AnimationCurve curve;
    public float animationTime;
    public bool isVertical;

    public float Offset => _offset;

    private float _timeForStep;
    private float _timeForAnimation;

    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    private float _offset;

    private void Awake() {
        _startPosition = _targetPosition = transform.position;
        _offset = from.GetComponent<SpriteRenderer>().size.x;
    }

    private void Update() {
        var transformPosition = transform.position;

        if (isVertical ? transformPosition.y + distance > _offset : transformPosition.x + distance > _offset) {
            if (isVertical) {
                transformPosition.y = from.position.x - _offset;
            }
            else {
                transformPosition.x = from.position.x - _offset;
            }

            transform.position = transformPosition;
        }

        _timeForStep += Time.deltaTime;
        _timeForAnimation += Time.deltaTime;
        if (_timeForStep > timeStep) {
            _timeForStep = 0;
            _timeForAnimation = 0;
            var x = isVertical ? transformPosition.x : transformPosition.x + distance;
            var y = isVertical ? transformPosition.y + distance : transformPosition.y;
            _targetPosition = new Vector2(x, y);
            _startPosition = transformPosition;
        }

        transform.position = Vector2.Lerp(_startPosition, _targetPosition,
            curve.Evaluate(_timeForAnimation / animationTime));
    }
}