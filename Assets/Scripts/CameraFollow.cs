using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset;
    private Transform _transform;

    protected void Start()
    {
        _transform = transform;
        _offset = (_transform.position - _player.position);
    }

    protected void LateUpdate()
    {
        Vector3 targetPosition = (_player.position + _offset);
        targetPosition.x = 0;
        _transform.position = targetPosition;
    }
}
