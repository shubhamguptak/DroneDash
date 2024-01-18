using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _horizontalMultiplier = 2.0f;
    [SerializeField] private float _speedIncreasePerPoint = 0.1f;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private DroneRotor _rotorFirst, _rotorSecond;

    private bool _isAlive = true;
    private float _horizontalInput;
    

    protected void FixedUpdate()
    {
        if (!_isAlive) return;

        Vector3 forwardMove = transform.forward * _speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * _horizontalInput * _speed * Time.fixedDeltaTime * _horizontalMultiplier;
        _rb.MovePosition(_rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis(S.HORIZONTAL);

        if (transform.position.y < S.DEATH_LIMIT)
        {
            Die();
        }
    }

    public void Die()
    {
        _isAlive = false;
        Invoke(S.RESTART, 2.0f);
        _rotorFirst.enabled = false;
        _rotorSecond.enabled = false;
        GameManager.instance.GameOver();
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void IncreaseSpeed() => _speed += _speedIncreasePerPoint;
}