using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float backgroundSpeed = 5.0f;
    public float backgroundDespawnPos = 6.78f;
    public float backgroundSpawnPos = 38.07f;

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= backgroundSpeed * Time.fixedDeltaTime;

        if (pos.x <= backgroundDespawnPos)
        {
            pos.x = backgroundSpawnPos;
        }

        transform.position = pos;
    }
}
