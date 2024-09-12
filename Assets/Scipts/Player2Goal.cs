using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Goal : MonoBehaviour
{
    PointCounter pointCounter;
    ResetHandler resetHandler;
    Player1Controls player1Controls;

    [SerializeField] float resetTime = 2.0f;

    void Awake()
    {
        resetHandler = FindObjectOfType<ResetHandler>();
        pointCounter = FindObjectOfType<PointCounter>();
        player1Controls = FindObjectOfType<Player1Controls>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Puck" && !resetHandler.isGoal)
        {
            resetHandler.isGoal = true;
            pointCounter.Player1Score();
            player1Controls.PlayerPowerUp();
            StartCoroutine(resetHandler.ResetPositions());
        }
    }
}
