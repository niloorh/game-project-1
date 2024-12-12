using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Material defaultMat;
    public Material yellowMat;
    public Material redMat;
    public MeshRenderer meshRenderer;
    public Collider triggerCollider;
    public bool isFogTile = false;

    private int visitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material = defaultMat;
        if (!isFogTile)
        {
            string key = "tile_" +
                gameObject.transform.position.x +
                "_" +
                gameObject.transform.position.z;
            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key, 0);
            }
            else
            {
                visitCount = PlayerPrefs.GetInt(key);
                if (visitCount == 2)
                {
                    meshRenderer.material = yellowMat;
                }
                else if (visitCount == 3)
                {
                    meshRenderer.material = redMat;
                }
                else if (visitCount == 4)
                {
                    meshRenderer.material = redMat;
                    triggerCollider.isTrigger = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("comming_from_puzzle_or_fog") != 1)
            {
                if (!isFogTile)
                {
                    string key = "tile_" +
                    gameObject.transform.position.x +
                    "_" +
                    gameObject.transform.position.z;
                    if (visitCount == 0)
                    {
                        visitCount++;
                        PlayerPrefs.SetInt(key, visitCount);
                        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 10);
                    }
                    else if (visitCount == 1)
                    {
                        meshRenderer.material = yellowMat;
                        visitCount++;
                        PlayerPrefs.SetInt(key, visitCount);
                        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 20);
                    }
                    else if (visitCount == 2)
                    {
                        meshRenderer.material = redMat;
                        visitCount++;
                        PlayerPrefs.SetInt(key, visitCount);
                        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 40);
                    }
                    else if (visitCount == 3)
                    {
                        triggerCollider.isTrigger = false;
                    }
                }
                else
                {
                    PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 10);
                }
            }
            else
            {
                if (!isFogTile)
                {
                    PlayerPrefs.SetInt("comming_from_puzzle_or_fog", 0);
                }
            }
        }
    }
}
