using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public int score;
    public string prefix;

    void Start()
    {
        this.text = GetComponent<Text>();
        this.score = 0;
    }

    public void IncrementScore()
    {
        score++;
        this.text.text = this.prefix + this.score;
        PlayerPrefs.SetInt("Score", this.score);
    }
}
