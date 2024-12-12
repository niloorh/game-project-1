using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle8_2Script : MonoBehaviour
{
    public TMP_InputField textField;
    public int puzzleNumber;

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
        if (textField.text.Equals("رد پا") || textField.text.Equals("ردپا"))
        {
            SceneManager.LoadScene("SceneP8-3");
        }
        else
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 10);
            PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
            SceneManager.LoadScene("MazeScene");
        }
    }
}
