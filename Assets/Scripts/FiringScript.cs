using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    bool cooldown;
    public float delay, force;
    public GameObject laser, target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cooldown)
        {
            StartCoroutine(FireLaser());
        }
    }

    IEnumerator FireLaser()
    {
        cooldown = true;
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        GameObject clone = Instantiate(laser, transform.position, Quaternion.LookRotation(dir));
       // clone.GetComponent<Rigidbody>().AddForce(dir * force);
        Destroy(clone, 5);
        yield return new WaitForSeconds(delay);
        cooldown = false;
    }
}
