using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : SteeringBehaviour
{
    public Boid leader;

    Vector3 targetPos;
    Vector3 worldTarget;
    Vector3 offset;
    public bool abs;
    // Start is called before the first frame update
    void Start()
    {
        // There is a bug here!!
        if(abs)
        offset =  new Vector3 (Mathf.Abs(transform.position.x - leader.transform.position.x), Mathf.Abs(transform.position.y - leader.transform.position.y), Mathf.Abs(transform.position.y - leader.transform.position.y));
        else
        {
            offset = transform.position - leader.transform.position;
        }
    }

    public override Vector3 Calculate()
    {
        worldTarget = leader.transform.TransformPoint(offset);

        float dist = Vector3.Distance(worldTarget, transform.position);
        float time = dist / boid.maxSpeed;
        targetPos = worldTarget + (leader.velocity * time);
        return boid.ArriveForce(targetPos);
    }

    public override System.Collections.IEnumerator StartMoving()
    {
        yield return null;
        Debug.Log("gmm");
    }

}
