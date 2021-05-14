using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform ball;

    public float subtractor;

    [SerializeField]
    public float speed = 30;

    Rigidbody2D rb, rbBall;
    void Start()
    {
        rbBall = ball.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //speed /= divider;
        //if (rbBall.velocity.x > 0)
        //    rb.position = new Vector2(transform.position.x, rbBall.position.y)*speed;
        //if (ball.position.x > 0)
        // rb.position = Vector2.Lerp(transform.position,new Vector2(transform.position.x, rbBall.position.y),time); //* speed;
        // rb.velocity = new Vector2(0, rbBall.velocity.y) * speed;
        float step = speed * Time.deltaTime;
        rb.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x,ball.position.y), step);
    }
}
