using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Player CurrentPlayer;
    private Vector3 CameraPos;
    private void Awake()
    {
        CurrentPlayer = GameObject.FindObjectOfType<Player>();
        CameraPos = new Vector3(CurrentPlayer.transform.position.x + 2.55f, transform.position.y, CurrentPlayer.transform.position.z - 2.55f);
    }
    private void Update()
    {
        CameraPos = new Vector3(CurrentPlayer.transform.position.x + 2.55f, transform.position.y, CurrentPlayer.transform.position.z - 2.55f);
        transform.position = CameraPos;
    }
}
