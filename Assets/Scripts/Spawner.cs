using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        spawnObj();
    }
    public void spawnObj()
    {
        GameObject newBall = objectPool.GetBall();
        newBall.transform.position = this.transform.position;
    }    
}
