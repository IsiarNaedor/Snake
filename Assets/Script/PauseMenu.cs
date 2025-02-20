using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else if (GameOverMenu.isGameOver == false)
            {
                PauseGame();
            }
        
        }
            
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;

    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;

    }

    public void RestartGame()
    {
        // pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        // isPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

    }
    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit(); 
    }

}
