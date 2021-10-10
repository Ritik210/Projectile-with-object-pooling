using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private Queue<GameObject> ballPool = new Queue<GameObject>();
    [SerializeField]
    private int poolStartSize = 5;

    private void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject b = Instantiate(ballPrefab);
            ballPool.Enqueue(b);
            b.SetActive(false);
        }
    }

    public GameObject GetBall ()
    {
        if (ballPool.Count > 0)
        {
            GameObject b = ballPool.Dequeue();
            b.SetActive(true);
            return b;
        }
        else
        {
            GameObject b = Instantiate(ballPrefab);
            return b;
        }
    }

    public void ReturnBall(GameObject ball)
    {
        ballPool.Enqueue(ball);
        ball.SetActive(false);
    }
}
