using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Checker : MonoBehaviour
{

    public GameObject roomchecker1;
    public GameObject roomchecker2;
    public GameObject roomchecker3;
    public GameObject roomchecker4;
    public GameObject roomchecker5;
    public GameObject roomchecker6;
    public GameObject roomchecker7;
    public bool Action = false;
    // Start is called before the first frame update
    void Start()
    {

        roomchecker1.SetActive(false);
        roomchecker2.SetActive(false);
        roomchecker3.SetActive(true);
        roomchecker4.SetActive(false);
        roomchecker5.SetActive(false);
        roomchecker6.SetActive(false);
        roomchecker7.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            roomchecker3.SetActive(true);
            Action = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            roomchecker2.SetActive(false);
            Action = false;
        }
    }
}
