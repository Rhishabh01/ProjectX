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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (gamepause)
            {
                disablePause();
               
            }
            else 
            {
                enablePause();
            }
        }
        
    }
    
    public void SwitchToGameScene()     // changes scene to game
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SwitchToGame() // changes to normal screen 
    {
        disablePause();
    }

    public void SwitchToSettings()
    {

    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



    public void disablePause()
    {
        sceneUI.SetActive(false);      
        
        Time.timeScale = 1f;
        gamepause = false;
    }

    public void enablePause()
    {
        sceneUI.SetActive(true);
        Time.timeScale = 0f;     
        gamepause = true;
    }


    

}
