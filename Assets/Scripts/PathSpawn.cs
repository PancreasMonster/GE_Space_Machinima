using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{

    BoidSpawner bs;
    Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        bs = GameObject.Find("EnemyShipManager").GetComponent<BoidSpawner>();
        points = GetComponentsInChildren<Transform>();
        foreach (Transform p in points)
        {
            p.position = bs.transform.TransformPoint(new Vector3(Random.Range(-1500, 1500), Random.Range(-1500, 1500), Random.Range(-1500, 1500)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
