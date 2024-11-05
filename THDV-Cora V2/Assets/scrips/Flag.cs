using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flag : MonoBehaviour
{
    [SerializeField] Transform initialSpawn;
    [SerializeField] GameObject winUI;

    [Header("Flag")]
    [SerializeField] GameObject flag;
    [SerializeField] GameObject throwableFlag;
    //GameObject lastFlag;
    GameObject nearestFlag;
    GameObject lastThrowableFlag;
    bool nearFlag;
    int flagAmmo = 0;
    [SerializeField] TextMeshProUGUI flagCounterUI;
   
    [Header("Player")]
    [SerializeField] Transform playerPos;
    [SerializeField] float throwForce;
    [SerializeField] float throwForceUP;
    [SerializeField] Transform throwPoint;
    [SerializeField] Transform throwPosition;
    public Vector3 respawnPos;
    PlayerMovementTutorial playerControl;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerMovementTutorial>();        
        nearFlag = false;
        winUI.SetActive(false);
        respawnPos = initialSpawn.position;
    }
    private void Update()
    {
        if (Puasa.GameIsPaused) return;
        //grab d bandera
        if (Input.GetKeyDown(KeyCode.E) && nearFlag == true)
        {
            GrabFlag();
        }

        //dropear en el lugar la bandera
        if (Input.GetKeyDown(KeyCode.Q) && flagAmmo >= 1 && playerControl.grounded==true ) 
        {
            //Debug.Log("toque la q pero con la flag puesta");
            DropFlag();         
        }
        // lanzamiento d bandera
        if (Input.GetKeyDown(KeyCode.Mouse0) && flagAmmo >= 1)
        {
            ThrowFlag();
        }
        // respawn
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            flagAmmo++;
            UpdateFlagHUD();
               
        }
    }
    private void Respawn()
    {
        Debug.Log("toque la r");
        playerPos.position = respawnPos;
        Destroy(nearestFlag);
        if (lastThrowableFlag != null)
        {
            Destroy(lastThrowableFlag); // Destruye la última baliza lanzada
            lastThrowableFlag = null; // Asegúrate de limpiar la referencia
        }
        respawnPos = initialSpawn.position; 

    }
   
    private void GrabFlag()
    {
        Debug.Log("toke la e");
        nearFlag = false;
        Destroy(nearestFlag);
        flagAmmo++;
        UpdateFlagHUD();
    }
    private void DropFlag()
    {
        flagAmmo --;
        respawnPos = playerPos.position;
        Instantiate(flag, playerPos.position, playerPos.rotation);
        UpdateFlagHUD();

        //flag.transform.position = playerPos.position;
        //flag.SetActive(true);
    }
    private void ThrowFlag()
    {
        flagAmmo--;
        GameObject projectile = Instantiate(throwableFlag, throwPoint.position, throwPosition.rotation);
        lastThrowableFlag = projectile;
        Debug.Log("Instanciado throwableFlag en posición: " + throwPoint.position);

        // Intentar obtener el componente throwableFlag
        throwableFlag throwableScript = projectile.GetComponent<throwableFlag>();

        if (throwableScript != null)
        {
            Debug.Log("throwableFlag encontrado. Asignando flagControl.");
            throwableScript.flagControl = this; // Asignamos esta instancia de Flag a flagControl
        }
        else
        {
            Debug.LogWarning("El componente throwableFlag no está presente en el objeto throwableFlag instanciado.");
        }

        // Agregar fuerza de lanzamiento
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        Vector3 forceDirection = throwPosition.transform.forward;
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwForceUP;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        //Debug.Log("Fuerza añadida al proyectil: " + forceToAdd);
        UpdateFlagHUD();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            nearFlag = true;
            nearestFlag = other.gameObject;
        }
        if (other.CompareTag("winZone"))
        {
            winUI.SetActive(true);
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
    private void UpdateFlagHUD()
    {
        
        if (flagCounterUI != null)
        {
            flagCounterUI.text = ": " + flagAmmo;
        }
        else
        {
            Debug.LogWarning("No se ha asignado el componente flagCounterText en el inspector.");
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
