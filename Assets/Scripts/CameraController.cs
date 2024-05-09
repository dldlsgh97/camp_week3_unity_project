using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 _distance = new Vector3(0, 0, -10);
    void Update()
    {
        transform.position = player.transform.position + _distance;
    }
}
