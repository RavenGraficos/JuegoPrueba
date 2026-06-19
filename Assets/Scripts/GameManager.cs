using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameTimer = 0f;
    public Vector3 inicialPositionPlayer;
    public Vector3 inicialPositionEnemy;
    public Text timerText; 

    public GameObject player;
    public GameObject enemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTimer = 120f;
        Time.timeScale = 1f;

        

    }


    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale > 0f) // Solo actualiza el temporizador si el juego está en ejecución
        {
            gameTimer -= Time.deltaTime;
            timerText.text = "Tiempo restante: " + Mathf.Floor(gameTimer).ToString() + "s";
            if (gameTimer <= 0f)
            {
                WinGame();
            }
        }
    }


    public void WinGame()
    {
        SceneManager.LoadScene (2);
        Time.timeScale = 0f; // Detiene el tiempo del juego
    }

    public void LoseGame()
    {
        SceneManager.LoadScene (3);
        Time.timeScale = 0f; // Detiene el tiempo del juego
    }


}
