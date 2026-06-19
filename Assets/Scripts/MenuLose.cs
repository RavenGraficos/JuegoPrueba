using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        SceneManager.LoadScene (1);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}