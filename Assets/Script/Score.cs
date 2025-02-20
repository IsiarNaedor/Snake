using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI scoreText;

    private float elapsedTime;
    private bool isTimerRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(elapsedTime).ToString();
        }
        //Debug.Log(elapsedTime);
    }
}
