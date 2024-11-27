using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int playerScore = 0;
    public int enemyScore = 0;

    [SerializeField] TextMeshProUGUI enemyScoreText;
    [SerializeField] TextMeshProUGUI playerScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyScoreText.text = enemyScore.ToString();
        playerScoreText.text = playerScore.ToString();
    }


    public void updateScore(string guy)
    {
        if(guy == "Player")
        {
            playerScore = playerScore + 1;
        }
        if(guy == "Enemy")
        {
            enemyScore = enemyScore + 1;
        }
    }
}
