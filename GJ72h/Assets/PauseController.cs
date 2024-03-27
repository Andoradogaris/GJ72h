using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class PauseController : MonoBehaviour
{
    public ProcessControls playerProcessControls;
    public ProcessControls menuProcessControls;
    
    public GameObject pauseMenu;
    public MenuGamepad menuGamepad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuProcessControls.GetIsStartKeyPressed())
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if (pauseMenu.activeSelf)
            {
                playerProcessControls.ToggleControls(false);
                menuGamepad.SelectionButton(0);
                Time.timeScale = 0;
                Debug.Log("Pause");
            } else
            {
                Resume();
                Debug.Log("Unpause");
            }
        }
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        resetTime();
    }
    
    
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    async Task resetTime()
    {
        Time.timeScale = 1;
        await Task.Delay(10);
        playerProcessControls.ToggleControls(true);

    }
    
}
