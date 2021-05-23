using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private Transform player;

    private Vector3 cameraVector;
    public float cameraDistance;

    void Update()
    {
        cameraVector = new Vector3(player.transform.position.x, player.transform.position.y, cameraDistance);
        camera.transform.position = cameraVector;
    }
}
