using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAssign : MonoBehaviour
{
    Pursue ps;
    BoidSpawner bs;
    float dist = 10000000;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<Pursue>();
        bs = GameObject.Find("AllyShipManager").GetComponent<BoidSpawner>();
        foreach (GameObject b in bs.agents)
        {
            if (Vector3.Distance(transform.position, b.transform.position) < dist)
            {
                dist = Vector3.Distance(transform.position, b.transform.position);
                ps.target = b.GetComponent<Boid>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
