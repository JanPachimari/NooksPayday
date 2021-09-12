using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsMainScript : MonoBehaviour
{
    bool firstMoneyCollected = false;
    float timer = 100f;
    [SerializeField] Text textTimer;
    AudioSource sfx;
    [SerializeField] AudioClip coin;
    bool hasPineapple = false;
    bool hasPizza = false;
    [SerializeField] Image pineappleImage;
    [SerializeField] Image pizzaImage;
    [SerializeField] AudioClip grab;
    [SerializeField] Text textQuest;
    [SerializeField] GameObject golem;
    [SerializeField] GameObject golemTrigger;
    [SerializeField] GameObject bee;
    [SerializeField] GameObject beeTrigger;
    [SerializeField] InputField inputField;
    [SerializeField] GameObject lockedDoor;
    [SerializeField] GameObject maisTrigger;
    [SerializeField] GameObject mais;
    bool doorUnlocked = false;
    [SerializeField] AudioClip newquest;
    [SerializeField] AudioClip questCompleted;
    bool golemTriggered = false;
    bool beeTriggered = false;
    bool maisTriggered = false;
    bool hofTriggered = false;
    bool doorTriggered = false;
    bool sideTriggered = false;
    bool palaceTriggered = false;
    [SerializeField] Text moneyText;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioClip bossBgm;
    public bool countingDown = true;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countingDown)
        {
            timer -= Time.deltaTime;
        }
        textTimer.text = timer.ToString("F2");

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit" + hit.collider.name);
                if (hit.collider.gameObject.name == "Pineapple")
                {
                    Destroy(hit.collider.gameObject);
                    hasPineapple = true;
                    sfx.PlayOneShot(grab);
                    pineappleImage.color = new Color(pineappleImage.color.r, pineappleImage.color.g, pineappleImage.color.b, 1f);
                }
                else if (hit.collider.gameObject.name == "Pizza")
                {
                    Destroy(hit.collider.gameObject);
                    hasPizza = true;
                    sfx.PlayOneShot(grab);
                    pizzaImage.color = new Color(pizzaImage.color.r, pizzaImage.color.g, pizzaImage.color.b, 1f);
                }
                else if (hit.collider.gameObject.name == "LockedDoor")
                {
                    inputField.gameObject.SetActive(true);
                    inputField.Select();
                    inputField.ActivateInputField();
                }
                else if (hit.collider.name.Contains("Soccer"))
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Rigidbody cubeRb = hit.collider.gameObject.GetComponent<Rigidbody>();
                        cubeRb.AddForce(this.transform.forward * 3000 * Time.deltaTime);
                        cubeRb.AddForce(this.transform.up * 3000 * Time.deltaTime);
                        sfx.PlayOneShot(grab);
                    }
                }
                else
                {
                    inputField.DeactivateInputField();
                    inputField.gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
        if (inputField.text == "69420" && !doorUnlocked)
        {
            doorUnlocked = true;
            Destroy(lockedDoor);
            Destroy(maisTrigger);
            Destroy(mais);
            textQuest.text = "Mr. Mais sagt:\n'Nice.'\n\nDu hast Tom Nooks Palast fast erreicht. Weiter so!";
            sfx.PlayOneShot(questCompleted);
            inputField.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exited trigger " + other.name);
        if (other.gameObject.name.Contains("money"))
        {
            Destroy(other.gameObject);
            timer += 10f;
            if (timer > 100f) timer = 100f;
            moneyText.color = new Color(moneyText.color.r, moneyText.color.g, moneyText.color.b, 1f);
            sfx.PlayOneShot(coin);
            if (!firstMoneyCollected)
            {
                firstMoneyCollected = true;
                sfx.PlayOneShot(newquest);
                textQuest.text = "Nur Geld kann Tom Nook bändigen.\nSammle es ein, um mehr Zeit zu bekommen. Der Timer kann jedoch nicht über 100 Sekunden gehen.";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GolemTrigger" && !hasPineapple && !hasPizza)
        {
            if (!golemTriggered)
            {
                sfx.PlayOneShot(newquest);
                golemTriggered = true;
            }
            Debug.Log("no pineapple no pizza");
            textQuest.text = "Der Golem sagt:\n'Alter, ich hab voll Bock auf 'ne Hawaii-Pizza. Ich lass' dich erst durch, wenn du mir 'ne Pizza und 'ne Ananas bringst. Die Pizza kannste bestimmt aus irgendnem Haus klauen. Und die Ananas ist bestimmt irgendwo vom Baum gefallen.'";
        }
        else if (other.gameObject.name == "GolemTrigger" && hasPineapple && !hasPizza)
        {
            if (!golemTriggered)
            {
                sfx.PlayOneShot(newquest);
                golemTriggered = true;
            }
            textQuest.text = "Der Golem sagt:\n'Alter, ich hab voll Bock auf 'ne Hawaii-Pizza. Ich lass' dich erst durch, wenn du mir 'ne Pizza und 'ne Ananas bringst. Die Pizza kannste bestimmt aus irgendnem Haus klauen. Und die Ananas ist bestimmt irgendwo vom Baum gefallen.'";
        }
        else if (other.gameObject.name == "GolemTrigger" && !hasPineapple && hasPizza)
        {
            if (!golemTriggered)
            {
                sfx.PlayOneShot(newquest);
                golemTriggered = true;
            }
            textQuest.text = "Der Golem sagt:\n'Alter, ich hab voll Bock auf 'ne Hawaii-Pizza. Ich lass' dich erst durch, wenn du mir 'ne Pizza und 'ne Ananas bringst. Die Pizza kannste bestimmt aus irgendnem Haus klauen. Und die Ananas ist bestimmt irgendwo vom Baum gefallen.'";
        }
        else if (other.gameObject.name == "GolemTrigger" && hasPineapple && hasPizza)
        {
            textQuest.text = "Der Golem sagt:\n'Krass, danke man. So, die werd' ich mir jetzt einverleiben. Du darfst weitergehen.'\n\nFinde einen Weg nach oben.";
            Destroy(golem);
            Destroy(golemTrigger);
            pineappleImage.color = new Color(0, 0, 0, 0);
            pizzaImage.color = new Color(0, 0, 0, 0);
            sfx.PlayOneShot(questCompleted);
        }
        else if (other.gameObject.name == "BeeTrigger")
        {
            if (!beeTriggered)
            {
                sfx.PlayOneShot(newquest);
                beeTriggered = true;
            }
            textQuest.text = "Die Biene sagt:\n'Die Welt geht drauf, aber das ist mir egal. Ich möchte nur spielen. Um an mir vorbeizukommen, musst du mich in Schere-Stein-Papier besiegen.'\n\nDrücke 1 für Schere.\nDrücke 2 für Stein.\nDrücke 3 für Papier.";
        }
        else if (other.gameObject.name == "MaisTrigger")
        {
            if (!maisTriggered)
            {
                sfx.PlayOneShot(newquest);
                maisTriggered = true;
            }
            textQuest.text = "Mr. Mais sagt:\n'Hilfe! Hilfe! Das Tor ist versperrt und ich weiß die Kombination nicht. Vielleicht findest du in einem nahegelegenen Häuschen eine Notiz. Versuche dann mit dem richtigen Code, die Tür zu öffnen.'";
        }
        else if (other.gameObject.name == "HofTrigger")
        {
            if (!hofTriggered)
            {
                sfx.PlayOneShot(newquest);
                hofTriggered = true;
            }
            textQuest.text = "Vorsicht!\nDer Palast ist streng bewacht. Wenn du dich im Radius der Wachen befindest, wird der Timer wesentlich schneller...\n\nFinde einen Weg in den Palast.";
        }
        else if (other.gameObject.name == "DoorTrigger")
        {
            if (!doorTriggered)
            {
                sfx.PlayOneShot(newquest);
                doorTriggered = true;
            }
            textQuest.text = "Mist!\nDer Haupteingang ist abgeschlossen. Ob es wohl einen Weg gibt, um die anderen Eingänge zu erreichen?";
        }
        else if (other.gameObject.name == "SideTrigger")
        {
            if (!sideTriggered)
            {
                sfx.PlayOneShot(newquest);
                sideTriggered = true;
            }
            textQuest.text = "Geschafft!\nEiner der Seiteneingänge muss doch garantiert auf sein. \n\nFinde einen Weg in den Palast.";
        }
        else if (other.gameObject.name == "PalaceTrigger")
        {
            if (!palaceTriggered)
            {
                palaceTriggered = true;
                sfx.PlayOneShot(newquest);
                bgm.clip = bossBgm;
                bgm.Play();
                textQuest.text = "FINAL BOSS!\n\nHindere Tom Nook daran,\nden Planeten zu zerstören.";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("DogSphere"))
        {
            Debug.Log("spotted by dog");
            timer -= 5 * Time.deltaTime;
        }
        else if (other.gameObject.name == "BeeTrigger")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                int enemyRandomTurn = Random.Range(0, 3);
                if (enemyRandomTurn == 0)
                {
                    textQuest.text = "Du hast Schere gespielt.\nDie Biene hat ebenfalls Schere gespielt.\nProbiere es nochmal!\n\nDrücke 1 für Schere.\nDrücke 2 für Stein.\nDrücke 3 für Papier.";
                }
                else if (enemyRandomTurn == 1)
                {
                    textQuest.text = "Du hast Schere gespielt.\nDie Biene hat Stein gespielt und gewonnen.\nProbiere es nochmal!\n\nDrücke 1 für Schere.\nDrücke 2 für Stein.\nDrücke 3 für Papier.";
                }
                else
                {
                    textQuest.text = "Du hast Schere gespielt.\nDie Biene hat Papier gespielt. Gewonnen!\n\nDie Biene sagt:\n'Och menno. Jetzt habe ich keine Lust mehr zu spielen. Bruder muss los.'";
                    Destroy(bee);
                    Destroy(beeTrigger);
                    sfx.PlayOneShot(questCompleted);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                int enemyRandomTurn = Random.Range(0, 3);
                if (enemyRandomTurn == 0)
                {
                    textQuest.text = "Du hast Stein gespielt.\nDie Biene hat Schere gespielt. Gewonnen!\n\nDie Biene sagt:\n'Och menno. Jetzt habe ich keine Lust mehr zu spielen. Bruder muss los.'";
                    Destroy(bee);
                    Destroy(beeTrigger);
                    sfx.PlayOneShot(questCompleted);
                }
                else if (enemyRandomTurn == 1)
                {
                    textQuest.text = "Du hast Stein gespielt.\nDie Biene hat ebenfalls Stein gespielt.\nProbiere es nochmal!\n\nDrücke 1 für Schere.\nDrücke 2 für Stein.\nDrücke 3 für Papier.";
                }
                else
                {
                    textQuest.text = "Du hast Stein gespielt.\nDie Biene hat Papier gespielt und gewonnen.\nProbiere es nochmal!\n\nDrücke 1 für Schere.\nDrücke 2 für Stein.\nDrücke 3 für Papier.";
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                int enemyRandomTurn = Random.Range(0, 3);
                if (enemyRandomTurn == 0)
                {
                    textQuest.text = "Du hast Papier gespielt.\nDie Biene hat Schere gespielt und gewonnen.\nProbiere es nochmal!\n\nDrücke 1 für Schere.\nDrücke 2 für Stein.\nDrücke 3 für Papier.";
                }
                else if (enemyRandomTurn == 1)
                {
                    sfx.PlayOneShot(questCompleted);
                    textQuest.text = "Du hast Papier gespielt.\nDie Biene hat Stein gespielt. Gewonnen!\n\nDie Biene sagt:\n'Och menno. Jetzt habe ich keine Lust mehr zu spielen. Bruder muss los.'";
                    Destroy(bee);
                    Destroy(beeTrigger);
                }
                else
                {
                    textQuest.text = "Du hast Papier gespielt.\nDie Biene hat ebenfalls Papier gespielt.\nProbiere es nochmal!\n\nDrücke 1 für Schere.\nDrücke 2 für Stein.\nDrücke 3 für Papier.";
                }
            }
            
        }
    }

}
