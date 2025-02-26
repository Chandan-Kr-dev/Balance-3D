using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerDeath : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; // Store initial position

        if (CheckPointManager.instance.HasCheckpoint() && CheckPointManager.instance.CanRespawn())
        {
            transform.position = CheckPointManager.instance.GetCheckpoint();
            
        }
        else
        {
            
        }
    }

    public void Die()
    {
        if (CheckPointManager.instance.CanRespawn())
        {
            CheckPointManager.instance.IncreaseRespawnCount();  // ✅ Now it increments correctly

            transform.position = CheckPointManager.instance.GetCheckpoint();
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Reset velocity

           
        }
        else
        {
           
            CheckPointManager.instance.ResetCheckpoint();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Die();
        }
    }
}