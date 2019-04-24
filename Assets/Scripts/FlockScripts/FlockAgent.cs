using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{

    Collider agentCol;
    public Collider AgentCol { get { return agentCol; } }
    public int targetNum;

    // Start is called before the first frame update
    void Start()
    {
        agentCol = GetComponent<Collider>();
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}
