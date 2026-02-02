using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    public GameObject fade;
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
        StartCoroutine(FadeEffect());
        Application.Quit();
    }
    public bool SwitchToGameScene(bool MouseActive)     // sets mouse lock?
    {
        
        MouseActive = true;
        return MouseActive;
    }

    public void SwitchToGame() // changes to game scene // play button
    {
        StartCoroutine(FadeEffect());

        fade.SetActive(true);
    }

    public void SwitchToSettings()
    {

    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
       
    }

    IEnumerator FadeEffect()
    {
        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene("SampleScene");
    }

}
