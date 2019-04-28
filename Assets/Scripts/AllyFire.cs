using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyFire : MonoBehaviour
{
    public GameObject laser, flock;
    public float delay;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FireLaser");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FireLaser()
    {
        yield return new WaitForSeconds(delay);
        Vector3 dir = flock.GetComponent<Flock>().agents[Random.Range(0, flock.GetComponent<Flock>().agents.Count-1)].transform.position - transform.position;
        dir.Normalize();
        GameObject clone = Instantiate(laser, transform.position, Quaternion.LookRotation(dir));
        Destroy(clone, 5);
        dir = flock.GetComponent<Flock>().agents[Random.Range(0, flock.GetComponent<Flock>().agents.Count - 1)].transform.position - transform.position;
        dir.Normalize();
        GameObject clone2 = Instantiate(laser, transform.position, Quaternion.LookRotation(dir));
        Destroy(clone2, 5);
        StartCoroutine("FireLaser");
    }
}
