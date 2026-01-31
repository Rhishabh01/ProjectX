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
    public bool SwitchToGameScene(bool MouseActive)     // sets mouse lock?
    {
        
        MouseActive = true;
        return MouseActive;
    }

    public void SwitchToGame() // changes to game scene // play button
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
