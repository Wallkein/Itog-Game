using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<FoxMove>().transform;
        }
    }

    private void Update()
    {
        pos = player.position;
        pos.z = -10f;
        pos.y += 3f;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}