using UnityEngine;
using UnityEngine.TerrainUtils;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;

    public float spawnDistance = 30f;
    public float spawnInterval = 10f;
    public float laneLength = 8f;
    public float spawnDistanceAhead = 50f;

    private float nextSpawnZ;

    void Start()
    {
        nextSpawnZ = player.position.z + 40f;

        // Pre-spawn a bunch at the start
        while (nextSpawnZ < player.position.z + spawnDistanceAhead)
        {
            SpawnObstacle();
        }
    }
    void Update()
    {
        // Keep spawning ahead as player moves
        while (nextSpawnZ < player.position.z + spawnDistanceAhead)
        {
            SpawnObstacle();
        }
    }
    void SpawnObstacle()
    {
        Terrain terrain = Terrain.activeTerrain;
        Vector3 terrainPos = Terrain.activeTerrain.transform.position;
        Vector3 terrainSize = Terrain.activeTerrain.terrainData.size;

        int lane = Random.Range(0, 3); // 0, 1, 2

        float xPos = laneLength * 1/3 * lane + 4f;
        Vector3 spawnPosition = new Vector3(xPos, terrainPos.y + 4f, nextSpawnZ);

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        nextSpawnZ += 10f; // spacing between obstacles
    }
}