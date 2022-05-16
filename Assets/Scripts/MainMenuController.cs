using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // public
    public GameObject mainScreen, aboutScreen;
    public Button playButton, backButton, quitButton;

    private void Start()
    {
        // select first button
        playButton.Select();
    }

    // load level 1
    public void OnButtonPlayGame()
    {
        SceneManager.LoadScene("1");
    }

    // set panels and select back button
    public void OnButtonAboutGame()
    {
        mainScreen.SetActive(false);
        aboutScreen.SetActive(true);
        backButton.Select();
    }

    // set panels and select play button
    public void OnButtonBack()
    {
        mainScreen.SetActive(true);
        aboutScreen.SetActive(false);
        playButton.Select();
    }

    // quit application
    public void OnButtonQuit()
    {
        Application.Quit();
    }
}
