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
        
    }

    public void FireLaser()
    {
        cooldown = true;
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        GameObject clone = Instantiate(laser, transform.position, Quaternion.LookRotation(dir));
        Destroy(clone, 5);
    }
}
