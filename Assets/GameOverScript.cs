using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] Image black;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (black.color.a > 0f)
        {
            black.color = new Color(black.color.r, black.color.g, black.color.b, black.color.a - Time.deltaTime);
        }
    }
}
