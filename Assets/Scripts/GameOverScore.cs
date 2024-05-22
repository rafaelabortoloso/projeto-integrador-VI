using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        var lastScore = PlayerPrefs.GetInt("Score");
        var textComponent = GetComponent<Text>();
        textComponent.text = textComponent.text + lastScore;
    }
}
