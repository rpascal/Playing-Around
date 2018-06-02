using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public BaseEnemy[] enemies;
    public Vector3 spawnValues;

    public Terrain terrain;
    public LayerMask TerrainLayer;
    public float TerrainPositionX, TerrainOppositeXPosition, TerrainOppositeZPosition, TerrainPositionZ, TerrainSizeX, TerrainSizeZ;

    public float initialWaitPeriod = 2f;
    public float maxSpawnWait = 2f;
    public float minSpawnWait = 1f;

    public bool isSpawning = true;

    void Awake() {
        TerrainPositionX = terrain.transform.position.x;
        TerrainPositionZ = terrain.transform.position.z;
        TerrainSizeX = terrain.terrainData.size.x;
        TerrainSizeZ = terrain.terrainData.size.z;
        TerrainOppositeXPosition = TerrainPositionX + TerrainSizeX;
        TerrainOppositeZPosition = TerrainPositionZ + TerrainSizeZ;

        StartCoroutine(spawner());

    }

    void Update() {
    }

    IEnumerator spawner() {
        yield return new WaitForSeconds(initialWaitPeriod);
        while (isSpawning) {
            Instantiate(getRandomEnemy(), getRandomEnemyPosition(), Quaternion.identity, transform);
            yield return new WaitForSeconds(Random.Range(minSpawnWait, maxSpawnWait));
        }
    }

    private BaseEnemy getRandomEnemy() {
        var enemyIndex = Random.Range(0, enemies.Length);
        return enemies[enemyIndex];
    }


    private Vector3 getRandomEnemyPosition() {
        RaycastHit hit;
        float terrainHeight = 0f;
        float randomX, randomY, randomZ;
        randomX = Random.Range(TerrainPositionX, TerrainOppositeXPosition);
        randomZ = Random.Range(TerrainPositionZ, TerrainOppositeZPosition);
        if (Physics.Raycast(new Vector3(randomX, 9999f, randomZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer)) {
            terrainHeight = hit.point.y;
        }
        randomY = terrainHeight;
        print(randomY);
        return new Vector3(randomX, 2, randomZ);
    }



}
