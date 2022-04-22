using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase.Storage;
using Firebase.Extensions;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField playerNameInput;
   
    [SerializeField] private TMPro.TMP_Text player1Name;
    [SerializeField] private TMPro.TMP_Text player2Name;
    [SerializeField] private TMPro.TMP_Text player1Score;
    [SerializeField] private TMPro.TMP_Text player2Score;
    //area where it will be triggered 
    
    public int score1;
    public int score2;

    public Text Result;
    public Image AIChoice;

   

    
    //when button is pressed this scene is loaded
    public void sceneManager()
    {
        SceneManager.LoadScene("Welcome");
    }
    //when button is pressed this scene is loaded
    public void sceneManager2()
    {
        SceneManager.LoadScene("Shop");
    }
   
   
        
   

    

    private void Awake()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Welcome":
                break;
            case "JapaneseLearningGameLevel":
              //  uniqueCodeOutput.text = FirebaseController._key;
                player1Name.text = "Player 1: " + FirebaseController._player1;
               
                break;
            case "Join":
                player1Name.text = "Player 1: " + FirebaseController._player1;
              
                break;
            case "MainGame":
                player1Name.text = "Player 1: " + FirebaseController._player1;
               
                player1Score.text = "Score: " + FirebaseController._player1Score;
                
                break;
            default:
                break;
        }
    }
    
    void Update()
    {
        //Winner();
        //player1Score.text = score1.ToString();
       // player2Score.text = score2.ToString();
       // if (SceneManager.GetActiveScene().name == "MainGame")
       // player1Name.text = "Player 1: " + FirebaseController._player1;
       // player2Name.text = "Player 2: " + FirebaseController._player2;
    }
    public static void NextScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    //Welcome Scene
    public void CreateGame(){
        if (playerNameInput.text != ""){
            StartCoroutine(FirebaseController.CreateGame(playerNameInput.text));
           
            }
    }

   

}
