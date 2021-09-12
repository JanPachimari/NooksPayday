using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonOutro : MonoBehaviour
{
    GameObject player;
    Camera cam;
    float timer = 0f;
    AudioSource sfx;
    [SerializeField] AudioClip outroMusic;
    bool musicTriggered = false;
    [SerializeField] Text credits;
    [SerializeField] Camera outroCamera;

    public bool outroActive = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        player = GameObject.Find("FPSController");
        sfx = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (outroActive)
        {
            timer += Time.deltaTime;
            cam.transform.position = new Vector3(0, 0, 0);
            player.SetActive(false);
            outroCamera.gameObject.SetActive(true);
        }
        if (timer > 2.5f && timer < 4.5f && outroActive)
        {
            transform.Rotate(Vector3.right * 70 * Time.deltaTime);
        }
        if (timer > 5f && outroActive)
        {
            transform.position += transform.up * 30 * Time.deltaTime;
        }
        if (timer > 2.5f && !musicTriggered)
        {
            musicTriggered = true;
            sfx.PlayOneShot(outroMusic);
        }
        if (timer > 10f)
        {
            credits.color = new Color(credits.color.r, credits.color.g, credits.color.b, credits.color.a + Time.deltaTime / 8);
        }
    }
}
