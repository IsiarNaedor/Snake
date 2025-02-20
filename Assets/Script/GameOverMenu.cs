using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public static bool isGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverMenu.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g")) {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);      
    }
    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit(); 
    }

}
