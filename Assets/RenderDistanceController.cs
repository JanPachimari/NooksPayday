using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDistanceController : MonoBehaviour
{
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0 && camera.farClipPlane < 1000)
        {
            camera.farClipPlane += 10;
        }
        else if (Input.mouseScrollDelta.y < 0 && camera.farClipPlane > 10)
        {
            camera.farClipPlane -= 10;
        }
    }
}
