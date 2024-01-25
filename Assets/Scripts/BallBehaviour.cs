using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    GameScoreUI score;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    float ballSpeed = 3.0f;
    float ballSpeedInitial = 3f;

    void Start()
    {
        ballSpeed = ballSpeedInitial;
        if(Random.Range(0.0f, 1.0f) < 0.5f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }
    }

    void Update()
    {
        transform.position += direction * ballSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("una collision con" + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Cambiar de direccion en eje X");
            direction.x = direction.x * -1;
            Debug.Log("Cambiar de direccion en eje Y");
            direction.y = Random.Range(-1f, 1f);
            ballSpeed += 0.5f;
        }
        else if(collision.gameObject.CompareTag("Boarder"))
        {
            Debug.Log("Cambiar de direccion en eje Y");
            direction.y = direction.y * -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Goal2"))
        {
            ResetBall();
            score.GoalsScoardPlayer1();
        }

        if (collision.CompareTag("Goal1"))
        {
            ResetBall();
            score.GoalsScoardPlayer2();
        }
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        ballSpeed = 3f;
        direction.x = direction.x * -1;
        direction.y = Random.Range(-1f, 1f);
    }
}
