using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore() {
        int currentScore = Int32.Parse(score.text);
        currentScore++;
        score.text = currentScore.ToString();
    }
}
