using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlScene : MonoBehaviour
{
    public GameObject sceneUI;
   
    public bool Uiwork;
    public bool gamepause = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.LeftWindows) )
        {
            gamepause = true;
            if (gamepause == true)
            {
                enablePause();
               
            }
            else 
            {
                disablePause();
            }
        }
        
    }
    
    public void SwitchToGameScene()     // changes scene to game
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SwitchToGame() // changes to game scene removing Pause options
    {
        sceneUI.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void SwitchToSettings()
    {

    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene(1);
        
    }



    public void disablePause()
    {
        sceneUI.SetActive(false);      
        Time.timeScale = 1f;
        gamepause = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void enablePause()
    {
        sceneUI.SetActive(true);
        Time.timeScale = 0f;     
        gamepause = true;
        Cursor.lockState = CursorLockMode.None;
    }


    

}
