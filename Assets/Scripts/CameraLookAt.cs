using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target;
    public float speed = 2.5f;
    public bool locked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        dir.Normalize();
        if (locked)
            transform.rotation = Quaternion.LookRotation(dir);
        else

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), speed * Time.deltaTime);
    }
}
