using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private bool shouldCount = true;
    private float score;
    
    void Update()
    {
        if(!shouldCount) { return; }
        
        score += Time.deltaTime *  scoreMultiplier;
        
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

    public void StartTimer()
    {
        shouldCount = true;
    }
    
    public void EndTimer()
    {
        shouldCount = false;

        scoreText.text = string.Empty;
    }
}
