using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Goal : MonoBehaviour
{
    PointCounter pointCounter;
    ResetHandler resetHandler;
    Player2Controls player2Controls;

    [SerializeField] float resetTime = 2.0f;

    void Awake()
    {
        resetHandler = FindObjectOfType<ResetHandler>();
        pointCounter = FindObjectOfType<PointCounter>();
        player2Controls = FindObjectOfType<Player2Controls>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Puck" && !resetHandler.isGoal)
        {
            resetHandler.isGoal = true;
            pointCounter.Player2Score();
            player2Controls.PlayerPowerUp();
            StartCoroutine(resetHandler.ResetPositions());
        }
    }
}
