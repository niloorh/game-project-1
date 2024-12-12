using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle5Script : MonoBehaviour
{
    public TMP_InputField textField;
    public TMP_Text errorOutput;
    public int puzzleNumber;
    private int wrongCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSubmit()
    {
        if (textField.text.Equals("142-3=139"))
        {
            PlayerPrefs.SetInt("P" + puzzleNumber, 1);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 60);
            PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
            SceneManager.LoadScene("MazeScene");
        }
        else
        {
            wrongCount++;
            if (wrongCount > 3)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 10);
                PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
                SceneManager.LoadScene("MazeScene");
            }
            else
            {
                errorOutput.text = "Wrong! Attempts remaining: " + (4 - wrongCount).ToString();
            }
        }
    }
}
