using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager_Mono: MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI p1ScoreUI;

    private int p1Score = 0;
    private int p2Score = 0;
    private int volleyCount = 0;
    private int maxVolley = 0;
    
    [SerializeField]
    private TextMeshProUGUI p2ScoreUI;

    [SerializeField]
    private TextMeshProUGUI volleyCountUI;

    
    [SerializeField] 
    private GameObject ball; 
    
    public void PointScored(bool player1Scored)
    {
        if (player1Scored)
        {
            p1Score++;
            p1ScoreUI.text = p1Score.ToString();
        }
        else
        {
            p2Score++;
            p2ScoreUI.text = p2Score.ToString();
        }

        if (volleyCount > maxVolley)
        {
            maxVolley = volleyCount;
        }

        volleyCount = 0;
        volleyCountUI.text = volleyCount.ToString();

        ResetBall();
    }

    public void AddVolley()
    {
        volleyCount++;
        volleyCountUI.text = volleyCount.ToString();
    }
    
    public static void RestartGame()
    {
        
    }

    private void ResetBall()
    {
        ball.transform.position = new Vector3(0, 0, 0);
        ball.GetComponent<Ball_Mono>().velocity = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
