using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newlevel : MonoBehaviour
{
    //public GameObject endgame;

    private void Start()
    {
        //endgame.SetActive(false);
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            //endgame.SetActive(true);
            GameManager.NextScene("End");

        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
           // endgame.SetActive(false);

        }
    }


}
