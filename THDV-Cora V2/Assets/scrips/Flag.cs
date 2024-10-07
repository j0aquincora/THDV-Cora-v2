using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject flag;
    private bool hasFlag;
    public Transform playerPos;
    private Vector3 respawnPos;
    PlayerMovementTutorial playerControl;
    
     // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerMovementTutorial>();
        hasFlag = false;
        Debug.Log(hasFlag);
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) && hasFlag == true && playerControl.grounded==true ) 
        {
            Debug.Log("toque la q pero con la flag puesta");
            DropFlag();
            Debug.Log(hasFlag);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }


    }
    private void Respawn()
    {
        Debug.Log("toque la r");
        playerPos.position = respawnPos;
        //Destroy(flag);

    }
    private void DropFlag()
    {
        hasFlag = false;
        respawnPos = playerPos.position;
        Instantiate(flag, playerPos.position, playerPos.rotation);
        //flag.transform.position = playerPos.position;
        //flag.SetActive(true);
    }
    
    
    private void OnTriggerStay(Collider other)
    {
        //pickup bandera
        if (other.CompareTag("Flag"))
        {
            Debug.Log("siento la bandera cerca");
            if (Input.GetKeyDown(KeyCode.E) && hasFlag == false)
            {
                Debug.Log("toke la e");
                Destroy(other.gameObject);
                hasFlag = true;
                //flag.SetActive(false);
                Debug.Log(hasFlag);
            }

        }
    }
}
