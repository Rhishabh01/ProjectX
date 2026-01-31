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
    public void SwitchToGameScene()     // changes scene to game
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SwitchToGame() // changes to normal screen 
    {
        
    }

    public void SwitchToSettings()
    {

    }

 


}
