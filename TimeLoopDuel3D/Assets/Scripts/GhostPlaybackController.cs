using System.Collections.Generic;
using UnityEngine;

public class GhostPlaybackController : MonoBehaviour
{
    public List<GhostData> recording;
    private int recordingIndex;
    private float loopStartTime;
    private CombatController combatController;

    void Start()
    {
        loopStartTime = Time.time;
        combatController = GetComponent<CombatController>();
    }

    void Update()
    {
        if (recording != null && recording.Count > 0)
        {
            Playback();
        }
    }

    void Playback()
    {
        if (recordingIndex < recording.Count)
        {
            GhostData data = recording[recordingIndex];
            if (Time.time - loopStartTime >= data.time)
            {
                transform.position = data.position;
                transform.rotation = data.rotation;
                if (data.isAttacking && combatController != null)
                {
                    combatController.Shoot();
                }
                recordingIndex++;
            }
        }
    }
}
