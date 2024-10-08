using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akt1Manager : MonoBehaviour
{
    [HideInInspector]
    public bool introtextdone = false;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<CameraMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntroDone()
    {
        introtextdone = true;
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<CameraMovement>().enabled = true;
    }
    
    public void Akt1Done()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
