using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    Text startText;
    [SerializeField] Text buttonText;
    [SerializeField] Button button;
    float waitTime = 38f;
    float timer = 0f;
    bool fade = false;
    Image buttonImage;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = button.GetComponent<Image>();
        startText = GetComponent<Text>();
        startText.color = new Color(startText.color.r, startText.color.b, startText.color.g, 0);
        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.b, buttonImage.color.g, 0);
        buttonText.color = new Color(buttonText.color.r, buttonText.color.b, buttonText.color.g, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            fade = true;
        }
        if (fade)
        {
            if (startText.color.a < 1f)
            {
                startText.color = new Color(startText.color.r, startText.color.b, startText.color.g, startText.color.a + Time.deltaTime / 4);
            }
            if (buttonImage.color.a < 1f)
            {
                buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.b, buttonImage.color.g, buttonImage.color.a + Time.deltaTime / 4);
            }
            if (buttonText.color.a < 1f)
            {
                buttonText.color = new Color(buttonText.color.r, buttonText.color.b, buttonText.color.g, buttonText.color.a + Time.deltaTime / 4);
            }
        }
    }
}
