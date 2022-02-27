using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("NewGame");
        }

        pos = player.position;
        pos.z = -10f;
        pos.y += 3f;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
