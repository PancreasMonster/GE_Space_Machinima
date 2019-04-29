using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public ParticleSystem ps;
    public LineRenderer lr;
    public float lrWidth = 0, psLife = 0;
    public Transform cube1, cube2;
    public bool start, stop, startLaser, stopLaser;
    public AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(startCinematic());
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, cube1.position);
        lr.SetPosition(1, cube2.position);
        lr.startWidth = lrWidth;
        lr.endWidth = lrWidth;

        var main = ps.main;
        main.startLifetime = psLife;
        if(startLaser && lrWidth < 2*100 && !stopLaser)
        {
            lrWidth += 3f * 100 * Time.deltaTime;
        }

        if (stopLaser && lrWidth > 0)
        {
            lrWidth -= 3f * 100 * Time.deltaTime;
        }

        if (start && psLife < .66f * 25f && !stop)
        {
            psLife +=  .16f * 25f * Time.deltaTime;
        }

        if (stop)
        {
            psLife = 0;
        }
    }

    public void activate () 
    {
        StartCoroutine(startCinematic());
    }

    public IEnumerator startCinematic ()
    {
        aud.Play();
        start = true;
        yield return new WaitForSeconds(4.5f);
        startLaser = true;
        yield return new WaitForSeconds(.2f);
        stop = true;
        stopLaser = true;
        yield return new WaitForSeconds(2);
        lrWidth = 0;
    }
}
