using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] float moveSpeed = .1f;
    int currentScene = 0;
    bool isAlive = true;
    float speed = 0;
    private Vector3 lastPos;

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 MousePos = mousePosition;
        Vector3 MoveDirection = MousePos - transform.position;
        GetComponent<Rigidbody2D>().velocity = MoveDirection * moveSpeed;
        lastPos = transform.position;
        speed = Vector3.Distance(transform.position, lastPos) / Time.deltaTime;
        if (!isAlive)
        {
            FindObjectOfType<GameManager>().Dead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
            isAlive = false;
        }else if (collision.gameObject.tag == "Exit")
        {
            FindObjectOfType<GameManager>().NxtLvl();
            Debug.Log("exit");
        }
    }
}
