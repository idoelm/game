using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    Transform tr;
    public int speed = 7;
    private bool right = true;
    private EnemySpawner spawner;
    public GameObject playerDead;
    Vector3 LoseScreenPosition = new Vector3(0.0889f, 0.0902f, 0f);
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        rb.velocity = transform.right * speed;
        spawner = FindObjectOfType<EnemySpawner>();
        Vector3 spawnPosition = new Vector3(0.0889f, 0.0902f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("bullet"))
        {
          //  Debug.Log("bullet");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            spawner.KillCounter();
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
          //  Debug.Log("Player");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(playerDead, LoseScreenPosition, Quaternion.identity);
            Time.timeScale = 0f;
            enabled = false;
        }
        if (collision.gameObject.tag.Equals("RightWall"))
        {
            // Debug.Log("RightWall");
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            tr.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (collision.gameObject.tag.Equals("leftWall"))
        {
            // Debug.Log("LeftWall")
            rb.velocity = new Vector2(speed, rb.velocity.y);
            tr.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
