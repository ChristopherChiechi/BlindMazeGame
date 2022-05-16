using UnityEngine;

public class EndPointController : MonoBehaviour
{
    // variables
    public bool reachedEndpoint = false;
    public AudioClip soundToPlay;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // player reached endpoint
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            reachedEndpoint = true;
            audioSource.PlayOneShot(soundToPlay);
        }
    }
}
