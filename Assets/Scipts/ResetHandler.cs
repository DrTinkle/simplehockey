using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHandler : MonoBehaviour
{
    Player1Controls player1Controls;
    Player2Controls player2Controls;
    Puck puck;

    [SerializeField] float resetTime = 2.0f;

    public bool isGoal = false;

    void Awake()
    {
        player1Controls = FindObjectOfType<Player1Controls>();
        player2Controls = FindObjectOfType<Player2Controls>();
        puck = FindObjectOfType<Puck>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(ResetPositions());
        }
    }

    public IEnumerator ResetPositions()
    {
        yield return new WaitForSeconds(resetTime);
        player1Controls.ResetPosition();
        player2Controls.ResetPosition();
        puck.ResetPosition();
        isGoal = false;
        yield break;
    }
}
