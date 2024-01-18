using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _pathTile;
    private Transform _nextSpawnPoint;

    /// <summary>
    ///
    /// </summary>
    /// <param name="spawnItems">Spawn items</param>
    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(_pathTile, _nextSpawnPoint.position, Quaternion.identity);
        _nextSpawnPoint = temp.transform.GetChild(1);

        if (spawnItems)
        {
            PathTile pathTile = temp.GetComponent<PathTile>();
            pathTile.AddObstacles();
            pathTile.AddCoins();
        }
    }

    protected void Start()
    {
        _nextSpawnPoint = transform;
        for (int i = 0; i < 13; i++)
        {
            SpawnTile(i >= 4);
        }
    }
}

