using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBlock : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject ThisTrigger;
    public AudioSource Information1;
    public AudioSource Information2;
    public AudioSource Information3;
    public bool Action = false;
    // Start is called before the first frame update
    void Start()
    {
        Instructions.SetActive(false);
    }

     void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            Instructions.SetActive(true);
            Action = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instructions.SetActive(false);
            Action = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Action == true)
            {
                ThisTrigger.SetActive(false);
                Instructions.SetActive(false);
                Information1.Play();
                Action = false;
            }
        }
    }
}
