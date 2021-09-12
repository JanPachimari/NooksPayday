using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoneyScript : MonoBehaviour
{
    Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyText.color.a > 0f)
        {
            moneyText.color = new Color(moneyText.color.r, moneyText.color.g, moneyText.color.b, moneyText.color.a - Time.deltaTime / 2);
        }
    }
}
