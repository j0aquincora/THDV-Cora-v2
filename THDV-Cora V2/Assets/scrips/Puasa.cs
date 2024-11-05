using UnityEngine;
using UnityEngine.SceneManagement;

public class Puasa : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject controlUI;
    private GameObject player;
    private bool isPaused = false;
    private bool isShowing;

    public static bool GameIsPaused { get; private set; }

    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            player = GameObject.FindGameObjectWithTag("Player");
        }
        isShowing = false;
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
        controlUI.SetActive(false);
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
        controlUI.SetActive(false);
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
    public void ShowControls()
    {
        if (isShowing == false)
        {
            controlUI.SetActive(true);
            isShowing = true;
        }
        else
        {
            controlUI.SetActive(false);
            isShowing = false;
        }
    }
}
