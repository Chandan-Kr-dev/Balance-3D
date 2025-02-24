using UnityEngine;

public class LoadlnextLevel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject player;
    public Gamemanager gamemanager;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            gamemanager.LoadnextLevel();
            CheckPointManager.instance.ResetCheckpoint();
        }
    }
}
