using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject loadlevel;
    public GameObject PauseUI;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        loadlevel = GameObject.FindGameObjectWithTag("Loadlevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(Movemainmenu());

        }
        if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 2)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (PauseUI.activeInHierarchy)
                {
                    PauseUI.SetActive(false);
                    player.GetComponent<PLayerScript>().enabled=true;
                    Time.timeScale = 1f;
                }
                else
                {
                    PauseUI.SetActive(true);
                    player.GetComponent<PLayerScript>().enabled=false;
                    Time.timeScale = 0f;
                }
            }
        }
        
    }
    IEnumerator Movemainmenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");

    }
    public void LoadnextLevel()
    {
        

        SceneManager.LoadScene(2);
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelsMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void Restart(){
        CheckPointManager.instance.ResetCheckpoint();
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Level1()
    {
        SceneManager.LoadScene(3);
    }
    public void Level2()
    {
        SceneManager.LoadScene(4);
    }
    public void Level3()
    {
        SceneManager.LoadScene(5);
    }

}
