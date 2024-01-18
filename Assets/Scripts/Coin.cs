using UnityEngine;

public class Coin : MonoBehaviour
{
    private Transform _transform;

    protected void Awake() => _transform = transform;

    protected void OnTriggerEnter(Collider other)
    {
        if (!IsPlayer(other.gameObject))
        {
            return;
        }

        if (IsObstacle(other.gameObject))
        {
            Destroy(gameObject);
            return;
        }

        GameManager.instance.IncrementScore();
        Destroy(gameObject);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="gameObject">The Obstacle game object</param>
    /// <returns></returns>
    private bool IsObstacle(GameObject gameObject) => gameObject.GetComponent<Obstacle>() != null;

    /// <summary>
    ///
    /// </summary>
    /// <param name="gameObject">The player game object</param>
    /// <returns></returns>
    private bool IsPlayer(GameObject gameObject) => gameObject.name == S.PLAYER;

    protected void Update() => _transform.Rotate(0, 0, (S.COIN_ROTATION_SPEED * Time.deltaTime));
}
