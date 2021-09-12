using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{
    Image background;
    Text text;
    float waitTime = 4f;
    float timer = 0f;
    bool done = false;
    int total = 1;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (background.color.a < 0.5f && timer >= waitTime && !done)
        {
            background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a + Time.deltaTime / 4);
        }
        if (text.color.a < 1f && timer >= waitTime && !done)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + Time.deltaTime / 2);
        }
        if (timer >= 2 * waitTime)
        {
            done = true;
        }
        if (done)
        {
            if (background.color.a > 0f)
            {
                background.color = new Color(background.color.r, background.color.g, background.color.b, background.color.a - Time.deltaTime);
            }
            if (text.color.a > 0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - 2 * Time.deltaTime);
            }
        }
        if (timer >= 2.5 * waitTime)
        {
            timer = 3f;
            if (total < 3)
            {
                total++;
                done = false;
                Debug.Log("reset");
            }
        }
    }
}
