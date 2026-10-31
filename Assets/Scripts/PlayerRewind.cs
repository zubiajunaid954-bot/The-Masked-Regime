using UnityEngine;
using System.Collections.Generic;

public class PlayerRewind : MonoBehaviour
{
    public float rewindTime = 5f; // seconds to go back
    private List<Vector3> positions = new List<Vector3>();

    void Update()
    {
        RecordPosition();
    }

    void RecordPosition()
    {
        positions.Add(transform.position);

        int maxFrames = Mathf.RoundToInt(rewindTime / Time.deltaTime);
        if (positions.Count > maxFrames)
            positions.RemoveAt(0);
    }

    public void Rewind()
    {
        if (positions.Count == 0) return;

        transform.position = positions[0]; // rewind to oldest recorded position
    }
}
