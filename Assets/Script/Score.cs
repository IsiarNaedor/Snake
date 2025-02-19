using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI scoreText;

    private float elapsedTime;
    private int defaultScore = 0;
    private bool isTimerRunning = true;

    // Update is called once per frame
    void Update()
    {
        CheckReset();
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(elapsedTime).ToString();
        }
        //Debug.Log(elapsedTime);
    }

    private void CheckReset()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if(isTimerRunning)
            {
                isTimerRunning = false;
                Debug.Log("Timer is stopped");
            }
            else 
            { 
                isTimerRunning = true;
                Debug.Log("Timer is running");
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            elapsedTime = 0; // Reset the timer value
            scoreText.text = Mathf.FloorToInt(defaultScore).ToString(); // Update the UI
            Debug.Log("Reset timer");
        }

    }
}
