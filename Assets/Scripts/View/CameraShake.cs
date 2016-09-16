using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float shakeAmount;
    public float decreaseFactor;

    float _shakeAmount;
    float _decreaseFactor;
    Vector3 _originalPos;

    public void Shake() {
        _shakeAmount = shakeAmount;
        _decreaseFactor = decreaseFactor;
    }

    void OnEnable() {
        _originalPos = transform.localPosition;
    }

    void Update() {
        if(_shakeAmount > 0.0001) {
            transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;
            _shakeAmount *= _decreaseFactor;
        } else {
            _shakeAmount = 0;
            transform.localPosition = _originalPos;
        }
    }
}