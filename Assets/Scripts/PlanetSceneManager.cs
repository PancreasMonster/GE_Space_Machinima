using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlanetSceneManager : MonoBehaviour
{
    public Text text1, text2, text3;
    public CameraLookAt clt;
    public Camera cam1, cam2;
    public AudioSource aud;
    public Animator anim, anim2;
    public GameObject camPos;
    public List<GameObject> eyes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SceneManagement");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        }
    }

    IEnumerator SceneManagement()
    {
        yield return new WaitForSeconds(7);
        text1.text = "";
        text2.text = "";
        cam1.enabled = false;
        cam2.enabled = true;
        yield return new WaitForSeconds(1);
        anim.SetBool("CamSwing", true);
        yield return new WaitForSeconds(2);
        text3.text = "You're probably wondering why I've gathered you here.";
        anim2.SetBool("Speak", true);
        aud.Play();
        yield return new WaitForSeconds(2.9f);
        anim2.SetBool("Speak", false);
        yield return new WaitForSeconds(.1f);
        text3.text = "The enemy are on our damn doorstep...";
        anim2.SetBool("Speak", true);
        aud.Play();
        yield return new WaitForSeconds(2.9f);
        anim2.SetBool("Speak", false);
        yield return new WaitForSeconds(.1f);
        text3.text = "...and you're our last hope.";
        anim2.SetBool("Speak", true);
        aud.Play();
        yield return new WaitForSeconds(1f);
        clt.enabled = false;
        yield return null;
        camPos.transform.rotation = Quaternion.Euler(30, 0, 0);
        anim.SetBool("Pos2", true);
        yield return new WaitForSeconds(1.2f);
        anim2.SetBool("Speak", false);
        foreach (GameObject e in eyes)
        {
            e.GetComponent<CameraLookAt>().enabled = true;
        }
        yield return new WaitForSeconds(1f);
        anim.SetBool("CamSwing", false);
        anim.SetBool("Pos2", false);
        clt.enabled = true;
        text3.text = "Now prepare for briefing";
        anim2.SetBool("Speak", true);
        aud.Play();
    }
}
