using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject player;
    public int checkpointInervals = 30;

    private int frameCounter = 0;
    private bool isFinished = false;
    private int fogCount = 0;
    private Vector3 preFogPosition;
    private bool isInFog = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("score"))
        {
            //PlayerPrefs.SetInt("P1", 0);
            PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 0);
            PlayerPrefs.SetInt("is_in_fog", 0);
            PlayerPrefs.SetInt("scene7_blocked", 0);
            PlayerPrefs.SetInt("scene3_blocked", 0);
            PlayerPrefs.SetInt("score", 2000);
            PlayerPrefs.SetFloat("player_x", player.transform.position.x);
            PlayerPrefs.SetFloat("player_y", player.transform.position.y);
            PlayerPrefs.SetFloat("player_z", player.transform.position.z);
        }
        else
        {
            Vector3 playerPosition = new Vector3(
                PlayerPrefs.GetFloat("player_x"),
                PlayerPrefs.GetFloat("player_y"),
                PlayerPrefs.GetFloat("player_z"));
            player.transform.position = playerPosition;
            if (PlayerPrefs.GetInt("is_in_fog") == 1)
            {
                isInFog = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            scoreText.text = PlayerPrefs.GetInt("score").ToString();
            frameCounter++;
            if (frameCounter >= checkpointInervals)
            {
                frameCounter = 0;
                float x = PlayerPrefs.GetFloat("player_x");
                float y = PlayerPrefs.GetFloat("player_y");
                float z = PlayerPrefs.GetFloat("player_z");
                PlayerPrefs.SetFloat("player_x",
                        (player.transform.position.x * 0.75f) +
                        (x * 0.25f));
                PlayerPrefs.SetFloat("player_y",
                        (player.transform.position.y * 0.75f) +
                        (y * 0.25f));
                PlayerPrefs.SetFloat("player_z",
                        (player.transform.position.z * 0.75f) +
                        (z * 0.25f));
            }
            //if (PlayerPrefs.GetInt("comming_from_puzzle_or_fog") == 1)
            //{
            //    PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 0);
            //}
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (sceneName.Equals("SceneP7"))
        {
            if (PlayerPrefs.GetInt("scene7_blocked") == 1)
            {
                return;
            }
        }
        if (sceneName.Equals("SceneP3"))
        {
            if (PlayerPrefs.GetInt("scene3_blocked") == 1)
            {
                return;
            }
        }
        SceneManager.LoadScene(sceneName);
    }

    public void TeleportPLayer(Vector3 destinationTeleporterPosition)
    {
        player.transform.position = new Vector3(
            destinationTeleporterPosition.x,
            destinationTeleporterPosition.y + 2,
            destinationTeleporterPosition.z
            );
    }

    public void FinishGame()
    {
        isFinished = true;
        player.SetActive(false);
        int currentScore = PlayerPrefs.GetInt("score");
        currentScore += 2000;
        if (currentScore >= 3750)
        {
            scoreText.text = "You Won! Rank S, score: " + currentScore;
        }
        else if (currentScore >= 3650)
        {
            scoreText.text = "You Won! Rank A, score: " + currentScore;
        }
        else if (currentScore >= 3400)
        {
            scoreText.text = "You Won! Rank B, score: " + currentScore;
        }
        else
        {
            scoreText.text = "You Won! Rank C, score: " + currentScore;
        }
    }

    public void OnFogParentEnter()
    {
        fogCount = 0;
        isInFog = true;
        PlayerPrefs.SetInt("is_in_fog", 1);
        preFogPosition = new Vector3(
            PlayerPrefs.GetFloat("player_x"),
            PlayerPrefs.GetFloat("player_y"),
            PlayerPrefs.GetFloat("player_z")
        );
    }

    public void OnFogParentExit()
    {
        isInFog = false;
        PlayerPrefs.SetInt("is_in_fog", 0);
    }

    public void OnFogEnter(GameObject fog, bool isTeleportTile)
    {
        if (isInFog)
        {
            if (isTeleportTile)
            {
                fog.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                fogCount++;
                if (fogCount < 3)
                {
                    fog.GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    fogCount = 0;
                    PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
                    isInFog = false;
                    PlayerPrefs.SetInt("is_in_fog", 0);
                    player.transform.position = preFogPosition;
                }
            }
        }
        else
        {
            StartCoroutine(OnFogEnterAfterDelay(fog, isTeleportTile));
        }
    }

    IEnumerator OnFogEnterAfterDelay(GameObject fog, bool isTeleportTile)
    {
        yield return new WaitForSeconds(0.1f);
        if (isInFog)
        {
            OnFogEnter(fog, isTeleportTile);
        }
    }

    public void OnFogExit(GameObject fog)
    {
        fog.GetComponent<MeshRenderer>().enabled = true;
    }
}
