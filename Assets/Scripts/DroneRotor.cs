using UnityEngine;

public class DroneRotor : MonoBehaviour
{
    public float _rotationSpeed = 1000.0f;
    private Transform _rotorTransform;

    protected void Start() => _rotorTransform = transform;

    protected void Update() => _rotorTransform.Rotate(Vector3.up, (_rotationSpeed * Time.deltaTime), Space.World);
}
