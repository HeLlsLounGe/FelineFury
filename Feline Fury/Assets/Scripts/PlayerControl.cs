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
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        if (!isAlive)
        {
            SceneManager.LoadScene(currentScene);
        }
    }
}
