using UnityEngine;

public class PlayerWinScript : MonoBehaviour
{
    
    public Animator animator;
    public GameObject player;
    public Transform transformm;
    public GameObject Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        Camera=GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            animator.SetBool("won",true);
           
            
            player.transform.SetParent(transformm);
            Camera.GetComponent<CameraFollow>().enabled=false;
        }
    }
}
