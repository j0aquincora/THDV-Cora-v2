using UnityEngine;
using UnityEngine.SceneManagement;

public class Puasa : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private GameObject player;
    private bool isPaused = false;

    public static bool GameIsPaused { get; private set; }

    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameIsPaused = true;

        // Habilitar el cursor y permitir su uso
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameIsPaused = false;

        // Ocultar el cursor y bloquearlo en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
   
    public void QuitGame()
    {
        Debug.Log("Cerrando el juego...");
        Application.Quit();
    }

    public void RestartScene()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
