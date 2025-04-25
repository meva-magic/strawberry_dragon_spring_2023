using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;
    public GameObject Title;
    public GameObject Berry;

    PointManager pointManager;

    void Start()
    {
        Time.timeScale = 0;
        Title.SetActive(true);
        pointManager = GameObject.FindGameObjectWithTag("Point").GetComponent<PointManager>();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Title.SetActive(false);
        Berry.SetActive(true);
    }

}
