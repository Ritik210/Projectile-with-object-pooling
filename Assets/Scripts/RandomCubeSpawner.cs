using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubeSpawner : MonoBehaviour
{
    public Transform[] spwaners;
    public GameObject cubePrefab;
    public int rand;
    public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        cubeInstantiate();
    }
    public void cubeInstantiate()
    {
        rand = Random.Range(0, 9);
        a = Instantiate(cubePrefab, spwaners[rand].position, Quaternion.identity);

    }
}
