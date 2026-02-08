using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gameManager = GameManager.Instance;

        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        

        if (gameManager.IsGameOver())
        {
            return;
        }else {
            transform.position -= new Vector3(x, 0, 0);
        }

        if (transform.position.x <= -gameManager.obstacleOffsetX)
        {
            Destroy(gameObject);
        }
    }
}
