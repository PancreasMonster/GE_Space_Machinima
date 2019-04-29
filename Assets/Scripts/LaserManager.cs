using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public ParticleSystem ps;
    public LineRenderer lr;
    public float lrWidth = 0, psLife = 0;
    float lrWidthMax = 200;
    public Transform cube1, cube2, cube3, cube4;
    public bool start, stop, startLaser, stopLaser;
    public AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        lr.SetPosition(0, cube1.position);
        lr.SetPosition(1, cube2.position);
        lr.startWidth = lrWidth;
        lr.endWidth = lrWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
        lr.startWidth = lrWidth;
        lr.endWidth = lrWidth;
   
        var main = ps.main;
        main.startLifetime = psLife;
        if(startLaser && lrWidth < lrWidthMax && !stopLaser)
        {
            lrWidth += 3f * 100 * (lrWidthMax/200) * Time.deltaTime;
        }

        if (stopLaser && lrWidth > 0)
        {
            lrWidth -= 3f * 100 * (lrWidthMax / 200) * Time.deltaTime;
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

    public void activate2()
    {
        StartCoroutine(startCinematic2());
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

    public IEnumerator startCinematic2()
    {
        aud.Play();
        lr.SetPosition(0, cube3.position);
        lr.SetPosition(1, cube4.position);
        lrWidthMax = 400;
        yield return new WaitForSeconds(4.5f);
        stopLaser = false;
        startLaser = true;
        yield return new WaitForSeconds(.2f);
        stop = true;
        stopLaser = true;
        yield return new WaitForSeconds(2);
        lrWidth = 0;
    }
}
