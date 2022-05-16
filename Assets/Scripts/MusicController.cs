using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    // variables
    AudioSource audioSource;
    private static MusicController _instance;
    public static MusicController instance;

    // create singleton
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        instance = _instance;

        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
    }

    // enable music on main menu
    // disable music on level 5
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            audioSource.enabled = true;
        if (SceneManager.GetActiveScene().buildIndex == 5)
            audioSource.enabled = false;
    }
}
