using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    bool moveRight = true;
    [SerializeField] GameObject bee;
    [SerializeField] GameObject beeTrigger;
    [SerializeField] GameObject fps;
    [SerializeField] AudioClip questComplete;
    [SerializeField] Text questText;
    AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = fps.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 10)
        {
            moveRight = false;
        }
        else if (transform.position.x > 19)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position += new Vector3(-1, 0, 0) * 5 * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(1, 0, 0) * 5 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Soccer Ball"))
        {
            Destroy(bee);
            Destroy(beeTrigger);
            sfx.PlayOneShot(questComplete);
            questText.text = "Die Biene sagt:\n'Volltreffer! Gut gemacht.' :)";
            Destroy(this);
        }
    }

}
