using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAssign : MonoBehaviour
{
    FollowPath fp;
    BoidSpawner bs;
    public GameObject pathSpawn;
    float dist = 10000000;
    public List<GameObject> points = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        bs = GameObject.Find("EnemyShipManager").GetComponent<BoidSpawner>();  
        GameObject path = Instantiate(pathSpawn, transform.position, Quaternion.identity);
        path.transform.name = "PathFollow";
        fp = gameObject.GetComponent<FollowPath>();
        fp.path = path.GetComponent<Path>();
        fp.distance = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
