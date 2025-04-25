using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public float maxHealth = 100f;
    public float HP;
    public float bops;

    PlayerCollision player;
    PointManager pointManager;

    public void Start()
    {
        healthBar = GetComponent<Image>();
        HP = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
        pointManager = GameObject.FindGameObjectWithTag("Point").GetComponent<PointManager>();
    }

    public void DropTimer()
    {
        HP = 100f;
    }

    void Update()
    {
        if (HP <= 0)
        {
            player.GameOvered();
        }

        if (player.boom == 10)
        {
            DropTimer();
            HP = 100f;
            healthBar.fillAmount = HP / maxHealth;
            player.boom = 0;
        }

        else
        {
            HP -= 5 * Time.deltaTime;
            healthBar.fillAmount = HP / maxHealth;
        }
    }
}
