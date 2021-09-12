using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    [SerializeField] Image blackScreen;
    [SerializeField] Text dialogText;
    float timer = 0f;
    bool triggered_one = false;
    bool triggered_two = false;
    string text1 = "Du schon wieder.";
    string text2 = "Wie oft habe ich dir schon gesagt, dass du deine Schulden begleichen sollst?";
    string text3 = "Meine Geduld ist am Ende. Du lässt mir keine Alternative.";

    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = text1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (blackScreen.color.a > 0f)
        {
            blackScreen.color = new Color(0, 0, 0, blackScreen.color.a - Time.deltaTime / 8);
        }
        if (timer >= 10f && !triggered_one)
        {
            triggered_one = true;
            dialogText.text = text2;
        }
        if (timer >= 18f && !triggered_two)
        {
            triggered_two = true;
            dialogText.text = text3;
        }
    }
}
