using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private float elapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(elapsedTime).ToString();
    }
}
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class Score : MonoBehaviour
//{
//    public Text scoreText;
//    private float elapsedTime;

//    // Update is called once per frame
//    void Update()
//    {
//        Debug.Log(elapsedTime);
//        elapsedTime += Time.deltaTime;
//        scoreText.text = string.Format("0", elapsedTime);
//        scoreText.text += 1;
//    }
//}
