using UnityEngine;
using UnityEngine.UI;

public class TextControls : MonoBehaviour

{
    public Text controlsText;
    public float timer = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
            {
                timer = 0f;
                controlsText.enabled = false;
            }
    }
}
