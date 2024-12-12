using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle8_1Script : MonoBehaviour
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
        if (textField.text.Equals("ر") || textField.text.Equals("حرف ر"))
        {
            SceneManager.LoadScene("SceneP8-2");
        }
        else
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 10);
            PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 1);
            SceneManager.LoadScene("MazeScene");
        }
    }
}
