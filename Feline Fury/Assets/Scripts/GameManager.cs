using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int timesDied = 0;
    [SerializeField] TextMeshProUGUI passOutTXT;
    [SerializeField] AudioClip pop;
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameManager>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        passOutTXT.text = "Passed out " + timesDied.ToString() + " times";
    }

    public void Dead()
    {
        FindObjectOfType<GameManager>().GetComponent<AudioSource>().PlayOneShot(pop);
        timesDied++;
        int curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curScene);
        passOutTXT.text = "Passed out " + timesDied.ToString() + " times";
    }

    public void NxtLvl()
    {
        int nxtScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nxtScene);
    }
}
