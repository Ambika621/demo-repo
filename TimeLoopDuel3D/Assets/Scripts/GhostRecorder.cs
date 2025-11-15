using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    public List<GhostData> recording = new List<GhostData>();
    private bool isRecording = false;
    private float loopStartTime;

    void Update()
    {
        if (isRecording)
        {
            Record(false); // Default to not attacking
        }
    }

    public void StartRecording()
    {
        isRecording = true;
        recording.Clear();
        loopStartTime = Time.time;
    }

    public void RecordAttack()
    {
        if(isRecording)
        {
            Record(true);
        }
    }

    void Record(bool isAttacking)
    {
        recording.Add(new GhostData(Time.time - loopStartTime, transform.position, transform.rotation, isAttacking));
    }

    public void Stop()
    {
        isRecording = false;
    }

    public void Clear()
    {
        recording.Clear();
    }
}

[System.Serializable]
public class GhostData
{
    public float time;
    public Vector3 position;
    public Quaternion rotation;
    public bool isAttacking;

    public GhostData(float time, Vector3 position, Quaternion rotation, bool isAttacking)
    {
        this.time = time;
        this.position = position;
        this.rotation = rotation;
        this.isAttacking = isAttacking;
    }
}
