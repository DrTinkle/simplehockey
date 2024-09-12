using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI points1;
    [SerializeField] TextMeshProUGUI points2;
    [SerializeField] TextMeshProUGUI goal;
    [SerializeField] float goalTextDuration = 2.0f;

    public int player1Points = 0;
    public int player2Points = 0;

    void Start()
    {
        goal.enabled = false;
    }

    void Update()
    {
        UpdateScore();
    }

    public void Player1Score()
    {
        player1Points++;
        StartCoroutine(GoalDisplay());
    }

    public void Player2Score()
    {
        player2Points++;
        StartCoroutine(GoalDisplay());
    }

    void UpdateScore()
    {
        points1.text = player1Points.ToString();
        points2.text = player2Points.ToString();
    }

    IEnumerator GoalDisplay()
    {
        goal.enabled = true;
        yield return new WaitForSeconds(goalTextDuration);
        goal.enabled = false;
        yield break;
    }

}
