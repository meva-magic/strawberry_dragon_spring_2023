using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    LeaderBoard leaderBoard;
    public TMP_InputField playerNameInputfield;

    void Start()
    {
        StartCoroutine(SetupRoutine());

        leaderBoard = GameObject.FindGameObjectWithTag("Leader").GetComponent<LeaderBoard>();
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Succesfully set player name");
            }

            else
            {
                Debug.Log("Could not set player name" + response.Error);
            }
        });
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged it");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }

            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);
    }
    
    public IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderBoard.FetchTopHighscoresRoutine();
    }


    void Update()
    {
        
    }
}
