using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Save checkpoint position
            CheckPointManager.instance.SetCheckpoint(transform.position);
        }
    }
}
