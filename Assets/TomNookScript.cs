using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomNookScript : MonoBehaviour
{
    bool spinning = true;
    Rigidbody rb;
    [SerializeField] AudioSource bgm;
    AudioSource sfx;
    float waitTime = 5f;
    float timer = 0f;
    bool waiting = false;
    [SerializeField] AudioClip scream;
    [SerializeField] AudioClip victory;
    GameObject player;
    FpsMainScript fpsMain;
    GameObject moon;
    MoonOutro moonOutro;
    [SerializeField] Text questText;
    bool victoryTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
        player = GameObject.Find("FPSController");
        fpsMain = player.GetComponent<FpsMainScript>();
        moon = GameObject.Find("moon");
        moonOutro = moon.GetComponent<MoonOutro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            transform.Rotate(new Vector3(0, -1, 0) * 500 * Time.deltaTime);
        }
        if (waiting)
        {
            timer += Time.deltaTime;
        }
        if (timer >= waitTime && !victoryTriggered)
        {
            victoryTriggered = true;
            Debug.Log("VICTORY!");
            questText.text = "VICTORY!";
            questText.color = Color.cyan;
            sfx.PlayOneShot(victory);
        }
        if (timer >= 2 * waitTime)
        {
            moonOutro.outroActive = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Soccer") && spinning)
        {
            spinning = false;
            rb.useGravity = true;
            bgm.Stop();
            waiting = true;
            sfx.PlayOneShot(scream);
            fpsMain.countingDown = false;
            questText.text = "";
        }
    }
}
