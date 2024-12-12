using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject otherHalf;
    public GameObject gameManager;
    private bool ignoreNextTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setIgnoreNextTeleport(bool data)
    {
        ignoreNextTrigger = data;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool flag = true;
            if (PlayerPrefs.GetInt("comming_from_puzzle_or_fog") == 1)
            {
                flag = false;
            }
            if (ignoreNextTrigger)
            {
                flag = false;
                ignoreNextTrigger = false;
            }
            if(flag)
            {
                otherHalf.GetComponent<TeleportScript>().setIgnoreNextTeleport(true);
                gameManager.GetComponent<GameManager>().TeleportPLayer(otherHalf.transform.position);

            }
        }
    }
}
