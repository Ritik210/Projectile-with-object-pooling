using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BallProjectile : MonoBehaviour
{
	public GameObject ball;
	public Transform target;
	RandomCubeSpawner randomCubeSpawner;
	public float h = 25;
	public float gravity = -18;
	private ObjectPool objectPool;
	Spawner spawner;

	//public bool debugPath;

	void Start()
	{
		objectPool = FindObjectOfType<ObjectPool>();
		ball.GetComponent<Rigidbody>().useGravity = false;
		randomCubeSpawner = FindObjectOfType<RandomCubeSpawner>();
		spawner = FindObjectOfType<Spawner>();
		
	}

	private void remove()
	{
		if (objectPool != null)
			objectPool.ReturnBall(this.gameObject);
	}

	void Update()
	{
		target = randomCubeSpawner.spwaners[randomCubeSpawner.rand];
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Launch();
		}	
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "cube")
        {
			gameObject.SetActive(false);
			ball.GetComponent<Rigidbody>().useGravity = false;
			ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
			remove();
			spawner.spawnObj();
			Destroy(randomCubeSpawner.a);
			randomCubeSpawner.cubeInstantiate();
        }
    }

    void Launch()
	{
		Physics.gravity = Vector3.up * gravity;
		ball.GetComponent<Rigidbody>().useGravity = true;
		ball.GetComponent<Rigidbody>().velocity = CalculateLaunchData();
	}

	Vector3 CalculateLaunchData()
	{
		float displacementY = target.position.y - ball.GetComponent<Rigidbody>().position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - ball.GetComponent<Rigidbody>().position.x, 0, target.position.z - ball.GetComponent<Rigidbody>().position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;
		return velocityXZ + velocityY;
	}
}
