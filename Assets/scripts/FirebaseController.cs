using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;

[Serializable]
public class LobbyInstance
{
    public string _player1;
    //public int _timer = 0;int timer
    public int _player1Score = 0;
    public int timeTaken;
    public LobbyInstance(string player1, string v)
    {
        this._player1 = player1;
        //this._timer = timer;
        
    }
}



public class FirebaseController : MonoBehaviour
{


    public Text scoreText;
    private static DatabaseReference _dbRef;
    public static string _key = "";
    public static string _player1 = "";
    public static int _player1Score = 0;
   

     public void Update()
    {
        UpdateScore();

        _player1Score++;
    }
     void Start()
    {
        _dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance
        .GetReference("counter")
        .ValueChanged += HandleUpdateScore;
        DontDestroyOnLoad(this.gameObject);
        
    }
    public static IEnumerator UpdatePlayerScore(String player1)
    {
        _player1 = player1;

        yield return _dbRef.Child("Games").Child(_key).Child(player1).Child("_playerScore").SetValueAsync(_player1Score);
        
        

    }
    private void HandleUpdateScore(object sender, ValueChangedEventArgs args)
    {
        DataSnapshot snapshot = args.Snapshot;
        Debug.Log(snapshot.Value);
       // scoreText.text = snapshot.Value.ToString();
    }

    public void UpdateScore()
    {
        FirebaseDatabase.DefaultInstance
            .GetReference("counter")
            .GetValueAsync().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError(task);
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    int value = int.Parse(Convert.ToString(snapshot.Value));
                    value++;
                    _dbRef.Child("counter").SetValueAsync(value);
                }
            });
    }

    //When a player joins the lobby, we should know
    public static void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
       
    }

    //int timer timer
    public static IEnumerator CreateGame(string player1 )
    {

        _player1 = player1;
        LobbyInstance lobby = new LobbyInstance(player1, "");

        _key = _dbRef.Child("Games").Push().Key;

        yield return _dbRef.Child("Games").Child(_key).SetRawJsonValueAsync(JsonUtility.ToJson(lobby));
        //Listen to any changes in this lobby
        _dbRef.Child("Games").Child(_key).ValueChanged += HandleValueChanged;
        GameManager.NextScene("JapaneseLearningGameLevel");
    }



}
