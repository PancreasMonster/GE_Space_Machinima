using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;
    public List<Transform> targets = new List<Transform>();

    [Range(1, 500)]
    public int startingSize = 100;
    public float AgentDensity = 0.58f;

    [Range(1f, 1000f)]
    public float driveFactor = 10f;
    [Range(1f, 1000f)]
    public float maxSpeed = 5f;
    [Range(1f, 1000f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1000f)]
    public float avoidanceRadius = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadius * avoidanceRadius;

        for (int i = 0; i < startingSize; i++)
        {
            FlockAgent newAgent = Instantiate(agentPrefab,
                Random.insideUnitSphere * startingSize * AgentDensity,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
            newAgent.GetComponent<FiringScript>().target = targets[0].gameObject;
            newAgent.GetComponent<FiringScript>().force = 15000;
            newAgent.GetComponent<FlockAgent>().targetNum = Random.Range(0, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            
            //for Testing
            //agent.GetComponentInChildren<Renderer>().material.color = Color.Lerp(Color.white, Color.red, context.Count / 6f);

            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);
        foreach (Collider c in contextColliders)
        {
            if (c != agent.AgentCol)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
