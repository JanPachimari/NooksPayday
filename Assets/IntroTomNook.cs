using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTomNook : MonoBehaviour
{
    [SerializeField] GameObject head;
    bool headTurning = false;
    float waitTime = 18f;
    float timer = 0f;
    AudioSource sfx;
    [SerializeField] AudioClip tom1, tom2, tom3, tom4, tom5;
    bool triggered_one = false;
    bool triggered_two = false;
    bool triggered_three = false;
    bool triggered_four = false;
    bool triggered_five = false;
    [SerializeField] Camera cam;
    Animator anim;
    bool ascend = false;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (headTurning)
        {
            head.transform.Rotate(new Vector3(-1, 0, 0) * 500 * Time.deltaTime);
        }
        if (timer >= waitTime && !headTurning)
        {
            headTurning = true;
        }
        if (timer >= waitTime + 0.3f && headTurning)
        {
            headTurning = false;
        }
        if (timer >= 4.5f && !triggered_one)
        {
            triggered_one = true;
            sfx.PlayOneShot(tom1);
        }
        if (timer >= 11.3f && !triggered_two)
        {
            triggered_two = true;
            sfx.PlayOneShot(tom2);
        }
        if (timer >= 18.5f && !triggered_three)
        {
            triggered_three = true;
            sfx.PlayOneShot(tom3);
        }
        if (timer > 24f && timer < 25f)
        {
            transform.position += new Vector3(1, 0, 0.3f) * 50 * Time.deltaTime;
            Debug.Log("anim start");
        }
        if(timer > 25f && !triggered_four)
        {
            triggered_four = true;
            head.transform.localRotation = Quaternion.identity;
            transform.Rotate(new Vector3(0, 90, 0));
        }
        if(timer > 25.5f && timer < 26.6f)
        {
            cam.transform.Rotate(new Vector3(0, 3, 0) * 20 * Time.deltaTime);
        }
        if(timer > 27f && !triggered_five)
        {
            triggered_five = true;
            sfx.PlayOneShot(tom4);
            anim.SetBool("gocrazy", true);
            ascend = true;
        }
        if (ascend)
        {
            transform.position += Vector3.up * 5 * Time.deltaTime;
        }
    }
}
