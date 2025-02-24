using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject loadlevel;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        loadlevel=GameObject.FindGameObjectWithTag("Loadlevel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadnextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
