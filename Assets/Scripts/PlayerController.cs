using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody thisRigidbody;
    public float jumpPower = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collision)
    {
        bool isCheckpoint = collision.gameObject.CompareTag("Checkpoint");
        if (isCheckpoint)
        {
            GameManager.Instance.score++;
            Debug.Log("Score: " + GameManager.Instance.score);
        } else
        {
            GameManager.Instance.EndGame();
            Debug.Log("Game Over");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        bool isCheckpoint = collision.gameObject.CompareTag("Checkpoint");
        if (isCheckpoint)
        {
            GameManager.Instance.score++;
            Debug.Log("Score: " + GameManager.Instance.score);
        } else
        {
            GameManager.Instance.EndGame();
            Debug.Log("Game Over");
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool isGameActive = GameManager.Instance.IsGameActive();
        var isJumpActive = Keyboard.current.spaceKey.wasPressedThisFrame && isGameActive;
        if (isJumpActive)
        {
            thisRigidbody.linearVelocity = Vector3.zero;
            thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
}
