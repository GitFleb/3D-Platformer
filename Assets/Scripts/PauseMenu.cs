using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject Canvas;
    [SerializeField] public GameObject Camera;
    bool Paused = false;
    void Start()
    {
        Canvas.gameObject.SetActive(false);    
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(Paused == true)
            { 
                Time.timeScale = 1.0f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Canvas.gameObject.SetActive(false);
                GetComponent<PlayerMovement>().enabled = true;
                Paused = false;
            }

            else
            {
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Canvas.gameObject.SetActive(true);
                GetComponent<PlayerMovement>().enabled = false;
                Paused = true;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        Canvas.gameObject.SetActive(false);
    }
}