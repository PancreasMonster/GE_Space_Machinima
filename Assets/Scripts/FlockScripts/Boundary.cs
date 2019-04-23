using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Boundary")]
public class Boundary : FlockBehaviour
{

    public Vector3 centre;
    public float radius = 15f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 centreOffset = centre - agent.transform.position;
        float t = centreOffset.magnitude / radius;
        if (t < .9f)
        {
            return Vector3.zero;
        }

        return centreOffset * t * t;
    }
}
