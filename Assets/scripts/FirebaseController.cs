using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.SceneManagement;

[Serializable]
public class LobbyInstance
{
    public string _player1;
    public float playertime;

    public LobbyInstance(string player1, float ptTime)
    {
        this._player1 = player1;
        this.playertime = ptTime;

    }
}

public class FirebaseController : MonoBehaviour
{
    public float timer = 0f;
    public static float finaltime;
    private static DatabaseReference _dbRef;
    public static string _key = "";
    public static string _player1 = "";
   

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "JapaneseLearningGameLevel")
        {
            timer += Time.deltaTime;
        }

        if (SceneManager.GetActiveScene().name == "End")
        {
            finaltime = timer;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
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
                //circle = child.Value.ToString();
            }
        }

    }
   

    public static IEnumerator CreateGame(string player1)
    {

        _player1 = player1;
        LobbyInstance lobby = new LobbyInstance(player1, 0);

        _key = _dbRef.Child("Games").Push().Key;

        yield return _dbRef.Child("Games").Child(_key).SetRawJsonValueAsync(JsonUtility.ToJson(lobby));
        //Listen to any changes in this lobby
        _dbRef.Child("Games").Child(_key).ValueChanged += HandleValueChanged;
        GameManager.NextScene("JapaneseLearningGameLevel");
    }

    public static IEnumerator CreateTime()
    {

        //_player1 = player1;
        //  LobbyInstance lobby = new LobbyInstance(player1, 0);

        //  _key = _dbRef.Child("Games").Push().Key;

        //yield return _dbRef.Child("Games").Child(_key).SetRawJsonValueAsync(JsonUtility.ToJson(lobby));
        //Listen to any changes in this lobby
        //  _dbRef.Child("Games").Child(_key).ValueChanged += HandleValueChanged;
        //GameManager.NextScene("JapaneseLearningGameLevel");

        yield return _dbRef.Child("Games").Child(_key).Child("playertime").SetValueAsync(finaltime);
    }
    


}