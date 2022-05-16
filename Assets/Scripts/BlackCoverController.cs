using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCoverController : MonoBehaviour
{
    // variables
    public PlayerController playerController;
    [SerializeField] GameObject player;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player reached endpoint, destroy black cover
        if (playerController.reachedEndpoint)
            Destroy(gameObject);
    }
}
