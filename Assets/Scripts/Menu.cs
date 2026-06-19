using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
