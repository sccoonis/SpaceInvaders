using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int highScore;
    
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    
    
    private string key = "HighScore";
    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 0);
        
        scoreUI.text = score.ToString("0000");
        highScoreUI.text = highScore.ToString("0000");
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = score.ToString("0000");
        
        if (score > highScore)
        {
            highScoreUI.text = score.ToString("0000");
        }
        
        highScoreUI.text = highScore.ToString("0000");
    }

    public void AddPoints(Enemy enemy)
    {
        score += enemy.pointValue;
    }

    private void OnDisable()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }
}
