using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Threading;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _enemySpawnRate = 1f;
    private float _enemyMaxSpawnRate = 5f;

    [SerializeField] private Collider _spawnZone;
    [SerializeField] private LayerMask _spawnLayerMask;

    private int _maxIterations = 100;

    private int _enemyPerMinute = 20;

    //Time in miliseconds
    private int _spawnRateIncreaseTimer = 60000;

    private Timer _timer;

    private void Start()
    {
        StartCoroutine(RepeatedSpawn());
        _timer = new Timer(IncreaseSpawnRate, null, 0, _spawnRateIncreaseTimer);
    }


    private void IncreaseSpawnRate(object o)
    {
        if(_enemyMaxSpawnRate < _enemySpawnRate)
        {
            return;
        }

        _enemySpawnRate *= 1.2f;
        Enemy.MaxHealth += 1;
    }

    private void SpawnEnemy()
    {
        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject(0);
        enemy.transform.position = GetRandomPointInsideBorders();
        enemy.SetActive(true);
    }

    private Vector3 GetFreePointToSpawn()
    {
        Vector3 spawnPosition = GetRandomPointInsideBorders();

        NavMeshHit hit;
        NavMesh.SamplePosition(spawnPosition, out hit, Mathf.Infinity, _spawnLayerMask);

        spawnPosition = hit.position;       

        Debug.Log(_maxIterations);
        Debug.Log(spawnPosition);

        return spawnPosition;
    }

    private Vector3 GetRandomPointInsideBorders()
    {
        float spawnPointX = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
        float spawnPointY = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);
        float spawnPointZ = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);

        return new Vector3(spawnPointX, spawnPointY, spawnPointZ);
    }

    private IEnumerator RepeatedSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(60 / (_enemyPerMinute * _enemySpawnRate));
            SpawnEnemy();
        }
    }
}
