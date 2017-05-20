using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMove : MonoBehaviour {
    Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();


    public void cameraMove()
    {
        camera.transform.Rotate(new Vector3(0, 10, 0));
    }
}
