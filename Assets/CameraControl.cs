using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Player CurrentPlayer;
    private Vector3 CameraPos;
    private Vector3 desiredPos;
    private void Awake()
    {
        CurrentPlayer = GameObject.FindObjectOfType<Player>();
        CameraPos = new Vector3(CurrentPlayer.transform.position.x + 3f, transform.position.y, CurrentPlayer.transform.position.z - 3f);
    }
    private void Update()
    {
        //CameraPos = new Vector3(CurrentPlayer.transform.position.x + 3f, transform.position.y, CurrentPlayer.transform.position.z - 3f);
        //transform.position = CameraPos;
        transform.position = new Vector3(CurrentPlayer.transform.position.x + 3f, transform.position.y, CurrentPlayer.transform.position.z - 3f);
    }
}
