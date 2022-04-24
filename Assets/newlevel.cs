using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newlevel : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
           
                GameManager.NextScene("End");
            
        }
    }

}
