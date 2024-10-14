using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [Header("Flag")]
    public GameObject flag;
    //public GameObject throwFlag;
    GameObject nearestFlag;
    bool nearFlag;
    int flagAmmo = 0;
    //private bool hasFlag;
    [Header("Player")]
    public Transform playerPos;
    [SerializeField] float throwForce;
    [SerializeField] Transform throwPoint;
    private Vector3 respawnPos;
    PlayerMovementTutorial playerControl;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerMovementTutorial>();        
        nearFlag = false;       
    }
    private void Update()
    {
        //grab d bandera
        if (Input.GetKeyDown(KeyCode.E) && nearFlag == true)
        {
            GrabFlag();
        }

        //dropear en el lugar la bandera
        if (Input.GetKeyDown(KeyCode.Q) && flagAmmo <= 1 && playerControl.grounded==true ) 
        {
            //Debug.Log("toque la q pero con la flag puesta");
            DropFlag();         
        }
        // lanzamiento d bandera
        if (Input.GetKeyDown(KeyCode.Mouse0) && flagAmmo <= 1)
        {
            ThrowFlag();
        }
        // respawn
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
        flagAmmo --;
        respawnPos = playerPos.position;
        Instantiate(flag, playerPos.position, playerPos.rotation);
        //flag.transform.position = playerPos.position;
        //flag.SetActive(true);
    }
    private void GrabFlag()
    {
        Debug.Log("toke la e");
        nearFlag = false;
        Destroy(nearestFlag);
        flagAmmo++;        
    }
    private void ThrowFlag()
    {
        // Instantiate the grenade at the throw point
        GameObject throwFlag = Instantiate(flag, throwPoint.position, throwPoint.rotation);

        // Get the Rigidbody component of the grenade
        Rigidbody rb = throwFlag.GetComponent<Rigidbody>();

        // Apply force to throw the grenade in the forward direction of the camera
        Vector3 throwDirection = playerControl.orientation.position;
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            nearFlag = true;
            nearestFlag = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            nearFlag = false;
            nearestFlag = other.gameObject;
        }
    }



   /* 
    METODO TRUCHO-NO SIRVE +
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
    */
}
