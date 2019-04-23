using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{

    public GameObject boidAgent;
    public List<GameObject> agents = new List<GameObject>();
    public int num;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < num; i++)
        {
            GameObject clone = Instantiate(boidAgent, transform.TransformPoint(new Vector3(Random.Range(-1500, 1500), Random.Range(-1500, 1500), Random.Range(-1500, 1500))), Quaternion.identity);
            agents.Add(clone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
