using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public float timeLimit = 120;
    public Text timeText, scoreText;

    private float remainingTime;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        remainingTime = timeLimit;
        DisplayRemainingTime();
        UpdateScoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        DisplayRemainingTime();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    private void DisplayRemainingTime()
    {
        if (!timeText)
            return;
        timeText.text = (int)remainingTime / 60 + " : " + remainingTime % 60;
    }

    private void UpdateScoreDisplay()
    {
        if (!scoreText)
            return;
        scoreText.text = score + "!";
    }
}
