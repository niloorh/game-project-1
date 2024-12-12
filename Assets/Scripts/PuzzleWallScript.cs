using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleWallScript : MonoBehaviour
{
    public GameObject gameManager;
    public int puzzleNumber;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("P" + puzzleNumber.ToString()) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.GetComponent<GameManager>().ChangeScene("SceneP" + puzzleNumber);
    }
}
