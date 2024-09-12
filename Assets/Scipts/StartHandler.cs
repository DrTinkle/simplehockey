using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandler : MonoBehaviour
{
    [SerializeField] Canvas startCanvas;
    [SerializeField] Canvas buttonCanvas;
    [SerializeField] Canvas onePlayerCanvas;
    [SerializeField] Canvas twoPlayerCanvas;
    [SerializeField] Canvas pointsSystem;

    Player2Controls player2Controls;

    void Awake()
    {
        player2Controls = FindObjectOfType<Player2Controls>();
    }

    void Start()
    {
        Time.timeScale = 0;
        startCanvas.enabled = true;
        buttonCanvas.enabled = true;
        onePlayerCanvas.enabled = false;
        twoPlayerCanvas.enabled = false;
        pointsSystem.enabled = false;
    }

    void Update()
    {
        StartGame();
    }

    public void OnePlayerSelected()
    {
        onePlayerCanvas.enabled = true;
        player2Controls.onePlayer = true;
        buttonCanvas.enabled = false;
    }

    public void TwoPlayerSelected()
    {
        twoPlayerCanvas.enabled = true;
        player2Controls.onePlayer = false;
        buttonCanvas.enabled = false;
    }

    void StartGame()
    {
        if (Input.GetKey(KeyCode.Space) && !buttonCanvas.enabled)
        {
            startCanvas.enabled = false;
            pointsSystem.enabled = true;
            Time.timeScale = 1;
        }
    }
}
