using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField]
    public GameObject applePrefab;
    public float speed;
    public float leftAndRightEdge = 24f;
    public float chanceToChangeDirection = 0.02f;
    public float secBetweenAppleDrops = 1f;

    private void Start()
    {
        Invoke("DropApple", 2f);
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }

    private void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secBetweenAppleDrops);
    }
}
