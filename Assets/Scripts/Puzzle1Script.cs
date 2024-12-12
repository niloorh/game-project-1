using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1Script : MonoBehaviour
{
    public TMP_InputField textField;
    public RTLTextMeshPro guideField;
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
        if (textField.text.Equals("داور"))
        {
            PlayerPrefs.SetInt("P" + puzzleNumber, 1);
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 60);
            PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
            SceneManager.LoadScene("MazeScene");
        }
        else
        {
            wrongCount++;
            if (wrongCount == 2)
            {
                guideField.text = "اشتباه بود! راهنمایی: د***";
            }
            else if (wrongCount == 4)
            {
                guideField.text = "اشتباه بود! راهنمایی: دا**";
            }
            else if(wrongCount > 4)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 10);
                PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
                SceneManager.LoadScene("MazeScene");
            }
        }
    }
}
