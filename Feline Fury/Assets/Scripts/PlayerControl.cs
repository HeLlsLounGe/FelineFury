using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float capsuleMoveSpeed = .1f;
    [SerializeField] float moveAtXSecs = 0f;
    [SerializeField] TextMeshProUGUI timerTXT;
    [SerializeField] Canvas timerCanv;
    private Vector3 mousePosition;
    private Vector3 lastPos;
    int currentScene = 0;
    bool moveAllow = true;
    bool isAlive = true;
    float movetimer = 4;
    float speed = 0;
    int seconds;

    private void Start()
    {
        moveAllow = false;
        movetimer = 4;
    }
    void Update()
    {
        //Debug.Log(movetimer);
        if (moveAllow)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 MousePos = mousePosition;
            Vector3 MoveDirection = MousePos - transform.position;
            GetComponent<Rigidbody2D>().velocity = MoveDirection * capsuleMoveSpeed;
            lastPos = transform.position;
            speed = Vector3.Distance(transform.position, lastPos) / Time.deltaTime;
        }else
        {
            timerCanv.enabled = true;
            movetimer -= Time.deltaTime;
            if (movetimer <= moveAtXSecs)
            {
                moveAllow = true;
                timerCanv.enabled = false;
                movetimer = 4;
            }
            else
            {
                timerTXT.text = seconds.ToString();
                seconds = (int)(movetimer % 60);
            }
        }
        if (!isAlive)
        {
            FindObjectOfType<GameManager>().Dead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hit")
        {
            movetimer = 4;
            isAlive = false;
        }
        else if (collision.gameObject.tag == "Exit")
        {
            movetimer = 4;
            Debug.Log("exit");
            FindObjectOfType<GameManager>().NxtLvl();
        }
    }
}
