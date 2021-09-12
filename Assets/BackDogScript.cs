using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDogScript : MonoBehaviour
{
    string state = "right";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "forward":
                transform.position += Vector3.forward * 2 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "right":
                transform.position += Vector3.right * 2 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case "backward":
                transform.position += Vector3.back * 2 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case "left":
                transform.position += Vector3.left * 2 * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
        }
        if (state == "forward" && transform.position.z > -137.5f)
        {
            state = "backward";
        }
        if (state == "right" && transform.position.x > 220f)
        {
            state = "left";
        }
        if (state == "backward" && transform.position.z < -170f)
        {
            state = "forward";
        }
        if (state == "left" && transform.position.x < 177f)
        {
            state = "right";
        }
    }
}
