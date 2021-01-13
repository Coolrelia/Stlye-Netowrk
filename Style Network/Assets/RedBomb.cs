using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBomb : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb;

    public GameObject explosionPrefab;
    private Vector3 position = new Vector2(-3, 2);
    private Vector3 explosion1Position = new Vector2(-2, 2);
    private Vector3 explosion2Position = new Vector2(-1, 2);

    private Vector3 otherPosition = new Vector2(-3, 0);
    private Vector3 explosion3Position = new Vector2(-2, 0);
    private Vector3 explosion4Position = new Vector2(-1, 0);

    private void Start()
    {
        rb.velocity = -transform.right * speed;
    }

    private void Update()
    {
        if(transform.position == position)
        {
            Instantiate(explosionPrefab, explosion1Position, Quaternion.identity);
            Instantiate(explosionPrefab, explosion2Position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(transform.position == otherPosition)
        {
            Instantiate(explosionPrefab, explosion3Position, Quaternion.identity);
            Instantiate(explosionPrefab, explosion4Position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.GetComponent<Player>() != null)
        {
            hitInfo.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
}
