using Firebase.Database;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour
{
    // public
    public GameObject mainScreen;
    public Button replayButton, mainMenuButton, quitButton;
    public static string time1, time2, time3, time4, time5, time6;
    public Text timeText1, timeText2, timeText3, timeText4, timeText5, timeText6;

    // private
    private string userID;
    private DatabaseReference dbReference;

    // start
    private void Start()
    {
        // select first button
        replayButton.Select();

        // convert text to string
        timeText1.text = time1;
        timeText2.text = time2;
        timeText3.text = time3;
        timeText4.text = time4;
        timeText5.text = time5;
        timeText6.text = time6;

        // add data to database
        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        CreateUser();
    }

    // create database user
    public void CreateUser()
    {
        User newUser = new User(timeText1.text, timeText2.text, timeText3.text, timeText4.text, timeText5.text, timeText6.text);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }

    // load level 1
    public void OnReplayButton()
    {
        SceneManager.LoadScene("1");
    }

    // load main menu
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // quit application
    public void OnButtonQuit()
    {
        Application.Quit();
    }
}
