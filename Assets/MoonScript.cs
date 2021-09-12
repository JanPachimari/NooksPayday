using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour
{
    float waitTime = 30f;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= waitTime && timer < waitTime + 8f)
        {
            transform.position += new Vector3(-1, 0, 2) * 30 * Time.deltaTime;
        }
    }
}
