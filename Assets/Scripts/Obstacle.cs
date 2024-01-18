using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerController _playerController;

	protected void Start () => _playerController = GameObject.FindObjectOfType<PlayerController>();

    /// <summary>
    ///
    /// </summary>
    /// <param name="collision">Other collision</param>
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == S.PLAYER)
        {
            _playerController.Die();
        }
    }
}