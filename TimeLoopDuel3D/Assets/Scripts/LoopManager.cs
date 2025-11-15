using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    public GhostRecorder playerRecorder;
    public HealthSystem playerHealth;
    public Transform playerSpawnPoint;
    public ObjectPool projectilePool;
    public ObjectPool ghostPool;
    public float loopDuration = 10f;

    private float loopTimer;
    private List<List<GhostData>> recordings = new List<List<GhostData>>();
    private int loopCount;

    void Start()
    {
        loopTimer = loopDuration;
        playerRecorder.StartRecording();
    }

    void Update()
    {
        loopTimer -= Time.deltaTime;
        if (loopTimer <= 0)
        {
            ResetLoop();
        }
    }

    void ResetLoop()
    {
        loopTimer = loopDuration;
        loopCount++;

        // Stop recording and store the data
        playerRecorder.Stop();
        recordings.Add(new List<GhostData>(playerRecorder.recording));

        // Deactivate all projectiles and ghosts
        for (int i = 0; i < projectilePool.transform.childCount; i++)
        {
            projectilePool.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < ghostPool.transform.childCount; i++)
        {
            ghostPool.transform.GetChild(i).gameObject.SetActive(false);
        }

        // Spawn ghosts
        foreach (var rec in recordings)
        {
            if (rec.Count > 0)
            {
                GameObject ghost = ghostPool.GetPooledObject();
                if (ghost != null)
                {
                    ghost.transform.position = rec[0].position;
                    ghost.transform.rotation = rec[0].rotation;
                    ghost.GetComponent<GhostPlaybackController>().recording = rec;
                    ghost.SetActive(true);
                }
            }
        }

        // Reset Player State
        playerRecorder.transform.position = playerSpawnPoint.position;
        playerHealth.ResetHealth();


        // Start new recording
        playerRecorder.StartRecording();
    }
}
