using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] powerups;

    private bool _stopSpawning = false;
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
            Vector3 randomPosToSpawn = new Vector3(Random.Range(-8.7f, 8.7f), 7.90f, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, randomPosToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(3.0f);

        while (_stopSpawning == false)
        {
            Vector3 randomPosToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 8.00f, 0);

            int randomPowerup = Random.Range(0, 3);

            Instantiate(powerups[randomPowerup], randomPosToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}