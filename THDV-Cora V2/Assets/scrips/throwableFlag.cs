using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwableFlag : MonoBehaviour
{
    public Flag flagControl; 
    Vector3 landingPos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("La baliza tocó el piso");
            landingPos = transform.position;
            SetRespawn();
        }
    }

    void SetRespawn()
    {
        if (flagControl != null)
        {
            flagControl.respawnPos = landingPos;
            Debug.Log("Respawn actualizado a: " + flagControl.respawnPos);
        }
        else
        {
            Debug.LogWarning("flagControl no está asignado en throwableFlag.");
        }
    }
}
