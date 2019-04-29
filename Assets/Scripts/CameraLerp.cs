using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerp : MonoBehaviour
{
    public Transform target, origTarget;

    // Start is called before the first frame update
    void Start()
    {
        origTarget = target;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 1 * Time.deltaTime);
    }

    public void JumpCam ()
    {
        transform.position = target.position;
    }
}
