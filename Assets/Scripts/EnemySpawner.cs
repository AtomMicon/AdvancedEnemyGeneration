using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _spawnPoint;
    [SerializeField] private float _spawnIntervalSec = 2f;
    [SerializeField] private float _spawnHeightOffset = 1f;
    [SerializeField] private Target _target;

    private void Start()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnIntervalSec);
        StartCoroutine(SpawnLoop(waitForSeconds));
    }

    private void OnDrawGizmos()
    {
        DrawSpawnPointGizmos(_spawnPoint, Color.red);
    }

    private void DrawSpawnPointGizmos(Vector3 position, Color color)
    {
        float sphereRadius = 0.3f;

        Gizmos.color = color;
        Gizmos.DrawSphere(position, sphereRadius);
    }

    private IEnumerator SpawnLoop(WaitForSeconds waitForSeconds)
    {
        while (enabled)
        {
            yield return waitForSeconds;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 chosenSpawner = _spawnPoint;
        Vector3 addHeight = new Vector3(0, _spawnHeightOffset, 0);
        Vector3 spawnPosition = chosenSpawner + addHeight;
        Enemy enemy = Instantiate(_enemyPrefab, chosenSpawner + addHeight, Quaternion.identity);

        enemy.TargetInitialize(_target);
    }
}