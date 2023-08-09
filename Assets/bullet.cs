using System;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed = 10;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("RightWall") || collision.gameObject.tag.Equals("leftWall"))
        {
            Debug.Log("RightWall/leftRight");
            Destroy(gameObject);
        }
    }

}
