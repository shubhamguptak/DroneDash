using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : MonoBehaviour
{
    private PathSpawn _pathSpawn;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject _obstaclePrefab;

    protected void Start() => _pathSpawn = FindObjectOfType<PathSpawn>();

    private void OnTriggerExit(Collider other)
    {
        _pathSpawn.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void AddObstacles()
    {
        int obstacleSpawnIndex = Random.Range(S.MINIMUM_OBSTACTLE_SPAWN_RANGE, S.MAXIMUM_OBSTACTLE_SPAWN_RANGE);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(_obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void AddCoins()
    {
        for (int i = 0; i < S.COINS_TO_SPAWN_IN_SINGLE_TILE; i++)
        {
            GameObject coin = Instantiate(_coinPrefab, transform);
            coin.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    private Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 randomPoint;
        do
        {
            randomPoint = new Vector3(
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        } while (randomPoint != collider.ClosestPoint(randomPoint));

        randomPoint.y = 1;
        return randomPoint;
    }
}
