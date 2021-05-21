using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    //Be sure to assign this a value in the designer.
    public Text ScoreText;

    private float timer;
    private float score;

    private void Start()
    {
        //Reset the timer to 0.
        timer = 0;
    }

    void Update()
    {

        timer += Time.deltaTime;

        score = Mathf.RoundToInt(timer);

            //We only need to update the text if the score changed.
            ScoreText.text = score.ToString();
            Debug.Log(score);

        
    }

}
