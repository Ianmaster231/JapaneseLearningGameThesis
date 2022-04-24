using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

[Serializable]
public class LobbyInstance
{
    public string _player1;
    public string circle;
    public string square;
    public int _player1Score = 0;

    public LobbyInstance(string player1, string player2)
    {
        this._player1 = player1;
        this.circle = player2;

    }
}

public class FirebaseController : MonoBehaviour
{
    private static DatabaseReference _dbRef;
    public static string _key = "";
    public static string _player1 = "";
    public static string circle = "";
    public static int _player1Score = 0;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }



    //When a player joins the lobby, we should know
    public static void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        foreach (var child in args.Snapshot.Children)
        {
            if (child.Key == "_player2")
            {
                circle = child.Value.ToString();
            }
        }

    }


    public static IEnumerator CreateGame(string player1)
    {

        _player1 = player1;
        LobbyInstance lobby = new LobbyInstance(player1, "");

        _key = _dbRef.Child("Games").Push().Key;

        yield return _dbRef.Child("Games").Child(_key).SetRawJsonValueAsync(JsonUtility.ToJson(lobby));
        //Listen to any changes in this lobby
        _dbRef.Child("Games").Child(_key).ValueChanged += HandleValueChanged;
        GameManager.NextScene("JapaneseLearningGameLevel");
    }

    public static IEnumerator CreateTime(string player1)
    {

        _player1 = player1;
        LobbyInstance lobby = new LobbyInstance(player1, "");

        _key = _dbRef.Child("Games").Push().Key;

        yield return _dbRef.Child("Games").Child(_key).SetRawJsonValueAsync(JsonUtility.ToJson(lobby));
        //Listen to any changes in this lobby
        _dbRef.Child("Games").Child(_key).ValueChanged += HandleValueChanged;
        //GameManager.NextScene("JapaneseLearningGameLevel");
    }

}