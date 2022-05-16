using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // variables
    public static GameController instance;
    public GameObject hudContainer, levelOverPanel, pausedPanel;

    public Text timeCounter, countdownText;
    private float startTime, elapsedTime;
    TimeSpan timePlaying;

    public PlayerController playerController;
    [SerializeField] GameObject player;

    public AudioClip soundToPlay;
    AudioSource audioSource;

    public bool gamePlaying { get; private set; }
    public int countdownTime;
    public bool isPaused = false;

    private void Awake()
    {
        instance = this;

        playerController = player.GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        gamePlaying = false;

        // begin game on tutorial levels
        // start timer on real levels
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                BeginGame();
                break;
            case 5:
                BeginGame();
                break;
            case 6:
                BeginGame();
                break;
            default:
                StartCoroutine(CountdownToStart());
                break;
        }
    }

    // begin game
    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    public void Update()
    {
        // is playing
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
        }

        // end game
        if (playerController.reachedEndpoint)
        {
            EndGame();
        }

        // pause game
        if (Input.GetKeyDown(KeyCode.Escape) && !playerController.reachedEndpoint)
            PauseGame();
    }

    // end of level
    private void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowLevelOverScreen", 0.5f);

        // load next level
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            playerController.reachedEndpoint = false;
        }

        // display timer on real levels
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                EndSceneController.time1 = timePlaying.ToString("mm':'ss'.'ff");
                break;
            case 3:
                EndSceneController.time2 = timePlaying.ToString("mm':'ss'.'ff");
                break;
            case 4:
                EndSceneController.time3 = timePlaying.ToString("mm':'ss'.'ff");
                break;
            case 7:
                EndSceneController.time4 = timePlaying.ToString("mm':'ss'.'ff");
                break;
            case 8:
                EndSceneController.time5 = timePlaying.ToString("mm':'ss'.'ff");
                break;
            case 9:
                EndSceneController.time6 = timePlaying.ToString("mm':'ss'.'ff");
                break;
            default:
                break;
        }
    }

    // level over screen
    public void ShowLevelOverScreen()
    {
        levelOverPanel.SetActive(true);
        hudContainer.SetActive(false);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        levelOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
    }

    // timer
    IEnumerator CountdownToStart()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2
            || SceneManager.GetActiveScene().buildIndex == 3
            || SceneManager.GetActiveScene().buildIndex == 4)
        audioSource.PlayOneShot(soundToPlay);

        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1.0f);
            countdownTime--;
        }

        BeginGame();
        countdownText.text = "GO!";

        yield return new WaitForSeconds(1.0f);
        countdownText.gameObject.SetActive(false);
    }

    // pause game
    public void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pausedPanel.SetActive(true);
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pausedPanel.SetActive(false);
            AudioListener.pause = false;
        }
    }
}
