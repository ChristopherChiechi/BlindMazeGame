using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // variables
    public AudioClip soundToPlay;
    AudioSource audioSource;
    public float volume;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // play and loop sound on collision with player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            audioSource.PlayOneShot(soundToPlay, volume);
            audioSource.PlayScheduled(AudioSettings.dspTime + soundToPlay.length);
        }
    }

    // stop sound on exit collision with player
    public void OnTriggerExit2D(Collider2D collision)
    {
        audioSource.Stop();
    }
}
