using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] bool moveAllow = true;
    [SerializeField] bool moveHoriz = true;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (moveAllow)
        {
            if (moveHoriz)
            {
                rb2d.velocity = new Vector2(speed, 0f);
            }
            else if (!moveHoriz)
            {
                rb2d.velocity = new Vector2(0f, speed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Rev")
        {
            speed = -speed;
        }
    }
}
