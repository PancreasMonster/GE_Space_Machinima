using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;



public class PlanetSceneManager : MonoBehaviour
{
    public Text text1, text2, text3;
    public CameraLookAt clt;
    public Camera cam1, cam2, cam3, cam4;
    public VideoPlayer vp;
    public AudioSource aud, aud2, aud3;
    public Animator anim, anim2, anim3;
    public GameObject camPos, RawI, squad, planet;
    public List<GameObject> eyes = new List<GameObject>();
    public LaserManager lm;
    public ParticleSystem ps;
    bool fade, start, stop;
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

        if (start && aud3.volume < .7f && !stop)
        {
            aud3.volume += .3f * Time.deltaTime;
        }

        if (start && stop && aud3.volume > 0f)
        {
            aud3.volume -= .1f * Time.deltaTime;
        }

        if (fade && vp.targetCameraAlpha > 0)
        {
       //     vp.targetCameraAlpha -= .1f * Time.deltaTime;
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
        yield return new WaitForSeconds(2.5f);
        text3.text = "";
        vp.Play();
        aud2.Play();
        yield return new WaitForSeconds(.1f);
        cam2.enabled = false;
        cam3.enabled = true;
        yield return new WaitForSeconds(3f);
        vp.Stop();
        text3.text = "This is the enemy's ultimate weapon.";
        aud.Play();
        yield return new WaitForSeconds(3f);
        text3.text = "Capable of destroying whole planets!";
        aud.Play();
        yield return new WaitForSeconds(2.5f);
        lm.activate();
        text3.text = "";
        yield return new WaitForSeconds(8f);
        RawI.SetActive(true);
        text3.text = "We need you out there now!";
        aud.Play();
        yield return new WaitForSeconds(2.75f);
        squad.SetActive(true);
        start = true;
        yield return new WaitForSeconds(.25f);
        RawI.SetActive(false);
        cam3.enabled = false;
        cam4.enabled = true;
        text3.text = "";
        aud2.Stop();
        yield return new WaitForSeconds(9f);
        stop = true;
        lm.activate2();
        yield return new WaitForSeconds(4.55f);
        ps.Play();
        yield return new WaitForSeconds(.5f);
        planet.SetActive(false);
        RawI.SetActive(true);
        anim3.SetBool("Fade", true);
        yield return new WaitForSeconds(1f);
        ps.Stop();
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
}
