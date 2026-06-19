using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public StaminaBar staminaBar;

    public Light playerLight;
    public bool lightOn = false;

    public GameManager gameManager;

    public CharacterController controller;
    public float gravity = -9.81f;
    public float jumpHeight = 0.5f;
    public float speed = 5f;
    private Vector3 velocity;

    public float maxHealth = 100f;
    public float currentHealth;

    public float stamina = 200f;
    public float currentStamina;
    public bool isRunning = false;

    void Start()
    {
        {
            healthBar = GameObject.Find("HealthBarr").GetComponent<HealthBar>();
            staminaBar = GameObject.Find("StaminaBar").GetComponent<StaminaBar>();

            gameManager = FindFirstObjectByType<GameManager>();

            playerLight.enabled = lightOn;
            currentHealth = maxHealth;
            currentStamina = stamina;

            healthBar.ChangeMaxHealth(maxHealth);
            staminaBar.ChangeMaxStamina(stamina);
        }
    }

    void Update()
    {
        //Moviemiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;

        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Salto del jugador
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        controller.Move(velocity * Time.deltaTime);

        //Correr
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0) 
        {
            speed = 10f;
            isRunning = true;
        }
        else
        {
            speed = 5f;
            
            isRunning = false;
        }

        if (isRunning)
        {
            currentStamina -= 50f * Time.deltaTime;
        }
        else if (currentStamina < stamina)
        {
            currentStamina += 25f * Time.deltaTime;
        }
        staminaBar.ChangeStamina(currentStamina);

        //Encender y apagar la linterna
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (lightOn)
            {
                lightOn=false;
            }
            else
            {
                lightOn=true;
            }
            turnOnOffLight();
        }

    }

    void turnOnOffLight()
    {
        if (lightOn)
        {
            playerLight.enabled = true;
        }
        else
        {
            playerLight.enabled = false;
        }

    }

    public void TakeDamage (float damage)
    {
        currentHealth -= damage;
        healthBar.ChangeHealth(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthBar.ChangeHealth(currentHealth);
            gameManager.LoseGame();
        }
    }
}



