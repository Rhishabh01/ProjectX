using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseGame()
    {
        Application.Quit();
    }
    public bool SwitchToGameScene(bool MouseActive)     // changes scene to game
    {
        
        MouseActive = true;
        return MouseActive;
    }

    public void SwitchToGame() // changes to normal screen 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SwitchToSettings()
    {

    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
       
    }


}
