using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    private float cooldown = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var gameManager = GameManager.Instance;

        if (gameManager.IsGameOver())
        {
            return;
        }

        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            cooldown = GameManager.Instance.obstacleInterval;

            // Spawn Obstacle
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            var prefab = gameManager.obstaclePrefabs[prefabIndex];

            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.yOffset.x, gameManager.yOffset.y);
            float z = -12;
            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, prefab.transform.rotation);
        }
    }
}
