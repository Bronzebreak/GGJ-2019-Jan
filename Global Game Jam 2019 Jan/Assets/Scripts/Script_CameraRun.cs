using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CameraRun : MonoBehaviour {
    public Transform MainCamera;

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(MainCamera.position.x + 0.1f, 0, -10);
    }
}
