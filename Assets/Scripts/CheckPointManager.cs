using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;

    private Vector3 lastCheckpointPosition;
    private bool checkpointSet = false;
    private static int respawnCount = 0;  // ✅ Make this static so it persists
    private int maxRespawns = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
        checkpointSet = true;
        respawnCount = 0; // ✅ Reset respawn count when a new checkpoint is reached
        Debug.Log("Checkpoint set at: " + position);
    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpointPosition;
    }

    public bool CanRespawn()
    {
        Debug.Log("CanRespawn() called - Checkpoint Set: " + checkpointSet + " | Respawn Count: " + respawnCount);
        return checkpointSet && respawnCount < maxRespawns;
    }

    public void IncreaseRespawnCount()
    {
        if (checkpointSet)
        {
            respawnCount++; // ✅ Now it correctly increases
            Debug.Log("Respawn Count Increased: " + respawnCount);
        }
    }

    public void ResetCheckpoint()
    {
        checkpointSet = false;
        respawnCount = 0;
        Debug.Log("Checkpoint Reset");
    }

    public bool HasCheckpoint()
    {
        return checkpointSet;
    }

    public int GetRespawnCount()
    {
        return respawnCount;
    }
}
