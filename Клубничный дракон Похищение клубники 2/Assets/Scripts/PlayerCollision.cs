using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{
    public GameObject effect;
    public GameObject bloodStain;
    public GameObject bigBloodStain;
    
    public LeaderBoard leaderBoard;
    public GameObject Title;
    public GameObject Berry;

    PointManager pointManager;
    BerrySpawn berrySpawn;
    PauseMenu pause;
    HealthBar healthBar;

    private Shake shake;

    public int boom = 0;

    private void Start()
    {
        leaderBoard = GameObject.FindGameObjectWithTag("Leader").GetComponent<LeaderBoard>();

        pointManager = GameObject.FindGameObjectWithTag("Point").GetComponent<PointManager>();

        berrySpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BerrySpawn>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        pause = GameObject.FindGameObjectWithTag("Finish").GetComponent<PauseMenu>();

        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.tag == "Wall")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            shake.CamShake();
            GameOvered();
        }

        if(collision.collider.gameObject.tag == "Berry")
        {   
            shake.CamShake();
            AudioManager.instance.Play("Pickup");

            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bloodStain, transform.position, Quaternion.identity);
            
            pointManager.UpdateScore(1);
            healthBar.HP = 100f;
            boom = 10;

            Destroy(collision.collider.gameObject);
            berrySpawn.SpawnBerries();
        }

        if(collision.collider.gameObject.tag == "BigBerry")
        {   
            shake.CamShake();
            AudioManager.instance.Play("Pickup");

            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bigBloodStain, transform.position, Quaternion.identity);

            pointManager.UpdateScore(5);
            healthBar.HP = 100f;
            boom = 10;

            Destroy(collision.collider.gameObject);
            
            berrySpawn.SpawnBerries();
        }
    }

    public void GameOvered()
    {
        Time.timeScale = 0;
        StartCoroutine(DieRoutine());
        Berry.SetActive(false);
        Title.SetActive(true);
        SceneManager.LoadScene("SampleScene");
        
    }

    public void SpawnBlood()
    {
        
    }

    public IEnumerator DieRoutine()
    {
        ..yield return leaderBoard.SubmitScoreRoutine(pointManager.score);
    }
}
