using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    public CameraLookAt clt;
    public CameraLerp cl;
    public Animator anim, anim2, anim3, anim4;
    public float timer;
    public LaserManager lm;
    public GameObject flagshipctarget, bomb, camS, leader, cube, cube2, camLTarget;
    public List<ParticleSystem> ps = new List<ParticleSystem>();
    public AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("FadeIn", true);
        StartCoroutine(SceneManagement());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Vector3.Distance(bomb.transform.position, cube2.transform.position) < 5f)
        {
            bomb.GetComponent<Seek>().weight = 0;
            bomb.GetComponent<Boid>().velocity = Vector3.zero;
        }
    }

    IEnumerator SceneManagement()
    {
        yield return new WaitForSeconds(18f);
        clt.speed = 1;
        clt.target = flagshipctarget.transform;
        yield return new WaitForSeconds(8f);
        clt.target = bomb.transform;
        yield return new WaitForSeconds(11f);
        cl.JumpCam();
        clt.target = leader.transform;
        camS.transform.localPosition = new Vector3(0, 400, -144);
        yield return new WaitForSeconds(20f);
        clt.target = flagshipctarget.transform;
        yield return new WaitForSeconds(8f);
        camS.transform.localPosition = new Vector3(0, 100, -350);
        clt.target = leader.transform;
        yield return new WaitForSeconds(15f);
        lm.activate();
        clt.target = cube.transform;
        yield return new WaitForSeconds(8f);
        clt.target = leader.transform;
        yield return new WaitForSeconds(3f);
        clt.target = flagshipctarget.transform;
        yield return new WaitForSeconds(5f);
        bomb.GetComponent<OffsetPursue>().weight = 0;
        bomb.GetComponent<Seek>().weight = 1;
        bomb.GetComponent<Boid>().maxSpeed = 80;
        bomb.GetComponent<Boid>().maxForce = 120;
        clt.target = bomb.transform;
        yield return new WaitForSeconds(12f);
        cl.target = camLTarget.transform;
        yield return new WaitForSeconds(5f);
        anim2.SetBool("Fall", true);
        aud.Play();
        ps[0].Play();
        ps[1].Play();
        yield return new WaitForSeconds(1.75f);
        clt.target = ps[2].transform;
        aud.Play();
        ps[2].Play();
        ps[3].Play();
        yield return new WaitForSeconds(1.75f);
        clt.target = ps[4].transform;
        aud.Play();
        ps[4].Play();
        ps[5].Play();
        yield return new WaitForSeconds(1.75f);
        clt.target = ps[6].transform;
        aud.Play();
        ps[6].Play();
        ps[7].Play();
        yield return new WaitForSeconds(1.75f);
        clt.target = ps[8].transform;
        aud.Play();
        ps[8].Play();
        ps[9].Play();
        yield return new WaitForSeconds(1.75f);
        clt.target = ps[10].transform;
        aud.Play();
        ps[10].Play();
        ps[11].Play();
        yield return new WaitForSeconds(3f);
        camS.transform.localPosition = new Vector3(0, 100, 150);
        clt.target = flagshipctarget.transform;
        cl.target = cl.origTarget;
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(8f);
        anim3.SetBool("Fade", true);
        yield return new WaitForSeconds(1.5f);
        anim4.SetBool("Fade", true);
        yield return new WaitForSeconds(4f);
        Application.Quit();
    }

    }
